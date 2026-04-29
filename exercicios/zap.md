# Desafio Técnico: Integração e Monitoramento Android Real-Time

**Entender esse documento já faz parte do teste. Leia com atenção.**

Se você ficar com alguma dúvida, pesquise e use sua melhor interpretação. 

## Visão Geral
O objetivo deste desafio é avaliar sua capacidade de criar uma arquitetura de sincronização de dados entre um ambiente restrito (Android OS) e uma aplicação externa, utilizando o **Redis** como intermediário (Message Broker/Data Store).

Você deverá construir um pipeline que leia mensagens do WhatsApp ou WhatsApp Business em tempo real e, simultaneamente, permita a inserção de contatos na agenda do dispositivo via API externa.

### Requisitos de Entrega:
**Código-fonte:** Link do repositório Git com o projeto

**Vídeo (Loom/YouTube unlisted):** Uma gravação somente da tela com você mostrando o que fez e explicando via áudio os seguintes pontos:
- Arquitetura da solução
- Todas as decisões técnicas tomadas
- Dificuldades que você teve
- Como você lidou com as limitações do Android
- Mostrando todo o código que você fez e explicando cada parte

## O Desafio Técnico

### O Cenário
O WhatsApp no Android armazena mensagens, contatos e metadados em bancos de dados SQLite localizados no diretório interno da aplicação. Seu objetivo é ler essas mensagens e salvar num banco de dados externo.

### Etapa 1: Ambiente e Setup
1.  Configurar um emulador Android
2.  Instalar o **WhatsApp Business**
3.  Ativar uma conta do WhatsApp (recomendamos que você use um número de teste ao invés de usar o seu próprio número)
4.  O foco está nos bancos de dados em: `/data/data/com.whatsapp.w4b/databases/` (especialmente o `msgstore.db`).

### Etapa 2: O Agente Nativo (Android Side)
Você deve desenvolver um binário nativo para rodar dentro do Android.
* **Linguagens permitidas:** Rust, Go, C++ ou Swift (via suporte NDK/Android).
* **Ação A (Leitura):** O binário que roda dentro do Android deve monitorar o banco SQLite de mensagens e, a cada nova inserção, enviar o conteúdo para uma instância do **Redis**.
* **Ação B (Escrita):** O mesmo binário deve "escutar" uma fila/tópico no Redis e, ao receber um novo comando, inserir um contato na agenda telefônica do Android (via `content insert` ou chamadas de API do sistema).

### Etapa 3: A Camada de Consumo (.NET Side)
Crie uma aplicação em **.NET (C#)** que servirá como interface externa:
1.  **Monitoramento:** Leia as mensagens do Redis e exiba-as no console (ou em um log/dashboard simples) em tempo real.
2.  **API de Contatos:** Exponha um endpoint `POST /contacts` que aceite o JSON:
    ```json
    {
      "name": "Nome do Contato",
      "number": "5511999999999"
    }
    ```
    Este endpoint deve publicar os dados no Redis para que o Agente Nativo processe a inserção no Android.


## 3. Critérios de Avaliação
Queremos avaliar seu processo de raciocínio, sua capacidade de lidar com o NDK e sua habilidade de resolução de problemas de baixo nível.

* **Arquitetura:** Como você resolveu a comunicação entre o binário nativo e o mundo externo?
* **Performance:** Eficiência na leitura do SQLite (polling vs observers)
* **Segurança e Resiliência:** Como o sistema lida com quedas de conexão com o Redis?
* **Domínio da Linguagem:** Uso correto de memória e concorrência na linguagem escolhida para o Android

No vídeo esperamos que você nos conte todo o caminho que você chegou para fazer esse software, inclusive todos os problemas que você teve. O processo de depuração é muito valioso para nós.

Depois desse teste haverá uma entrevista técnica onde você terá que explicar para o entrevistador tudo o que você fez e os motivos das suas escolhas. 

Terminou? Mande tudo para **vagas.dev@intelitrader.com.br**.
