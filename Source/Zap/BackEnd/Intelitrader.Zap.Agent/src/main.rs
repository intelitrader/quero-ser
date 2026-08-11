use redis::AsyncCommands;
use serde::{Deserialize, Serialize};
use std::time::Duration;

#[derive(Serialize, Deserialize, Debug)]
struct ContactDto {
    #[serde(rename = "Id")]
    id: String,
    #[serde(rename = "Name")]
    name: String,
    #[serde(rename = "Number")]
    number: serde_json::Value,
}

#[tokio::main]
async fn main() -> redis::RedisResult<()> {
    println!("🚀 Agente Rust em execução!");
    println!("📡 Escutando fila 'ws_queue_contacts' no Redis...");

    let client = redis::Client::open("redis://127.0.0.1/")?;
    let mut con = client.get_async_connection().await?;

    loop {
        // RPOP: Remove o último item da lista
        let result: Option<String> = con.rpop("ws_queue_contacts", None).await?;

        if let Some(json) = result {
            if let Ok(contact) = serde_json::from_str::<ContactDto>(&json) {
                let phone = contact.number["Value"].as_str().unwrap_or("N/A");
                println!("✅ [SUCESSO] Contato processado pelo Agente:");
                println!("   👤 Nome: {}", contact.name);
                println!("   📞 Tel:  {}", phone);
                println!("   🆔 GUID: {}", contact.id);
                println!("-------------------------------------------");
            }
        }

        // Sleep para não sobrecarregar o hardware do Android
        tokio::time::sleep(Duration::from_secs(1)).await;
    }
}