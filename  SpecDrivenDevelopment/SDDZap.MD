PROMPT SDD: Engenharia de Integração Real-Time (Android NDK & .NET 9)
Persona: Atue como um Arquiteto de Software Especialista em Sistemas de Baixa Latência e Engenharia de Concorrência.

🎯 Objetivo do Prompt
Desenvolver um ecossistema de sincronização bidirecional entre o ambiente restrito do Android (via NDK) e uma API .NET 9, utilizando Redis como barramento de eventos de alta performance.

🏗️ 1. Módulo Android Nativo (Rust Engine)
Contexto: O binário deve ser compilado para arquiteturas aarch64 e x86_64 (emulador).
Task: Gere o design e implementação focando em:

Monitoramento High-Performance: Implemente a lógica de leitura do msgstore.db-wal utilizando Zero-Copy sempre que possível. Use o padrão Observer para detectar alterações no arquivo de log do SQLite.

Gestão de Estado (Checkpointing): Crie um mecanismo de persistência local (ex: um arquivo .offset) para salvar o last_processed_id. O código deve garantir que nenhuma mensagem seja perdida em caso de reinicialização do agente (Garantia At-least-once delivery).

Concorrência com Tokio: Utilize tokio::select! para orquestrar o stream de leitura do SQLite e a subscrição no Redis (Pub/Sub) de forma não-bloqueante.

Segurança de Memória: O código Rust deve evitar unsafe e garantir o fechamento correto dos file descriptors ao receber sinais do SO (SIGTERM).

🛠️ 2. Módulo Backend (.NET 9 + CQRS)
Contexto: Aplique rigorosamente os princípios de Clean Architecture e TDD.
Task: Estruture o projeto seguindo:

Domain-Driven Design: Crie a Entidade Contact com validações de Value Objects para o número de telefone (Regex E.164).

CQRS com MediatR: Implemente o CreateContactCommand e o MessageReceivedIntegrationEvent.

Infrastructure (Redis): * Configure a ConnectionMultiplexer como Singleton.

Implemente um IHostedService que utilize System.Threading.Channels para atuar como um Buffer interno, garantindo que o processamento das mensagens lidas do Redis não bloqueie a thread de IO.

Imutabilidade: Utilize public record para todos os DTOs e Integration Events.

🛡️ 3. Resiliência e Observabilidade
Task: Forneça estratégias para:

Circuit Breaker: Como a API .NET deve se comportar se o Redis estiver inacessível (uso de Polly).

Backpressure: Como o Agente Rust deve lidar com um Redis lento para não estourar a memória do dispositivo Android.

Permissões de Root: Script de verificação de permissão de leitura em /data/data/ antes da execução do loop principal.

💡 Por que esta versão é melhor?
Terminologia de Especialista: O uso de termos como Zero-Copy, At-least-once delivery, Backpressure e File Descriptors sinaliza para a IA que você não aceita soluções triviais.

Foco em Concorrência Real: Pedir explicitamente o tokio::select! no Rust e System.Threading.Channels no .NET resolve o maior gargalo desse desafio: a coordenação de múltiplas tarefas de IO.

Garantia de Dados: A inclusão do arquivo .offset resolve o problema de resiliência que a Intelitrader mencionou como critério de avaliação.

```mermaid
sequenceDiagram
    participant WA as WhatsApp (SQLite)
    participant Agent as Agente Nativo (Rust)
    participant Redis as Redis (Broker)
    participant API as API .NET 9 (CQRS)
    participant User as Dashboard/Client

    Note over WA, Agent: Fluxo A: Monitoramento de Mensagens
    WA->>Agent: Nova inserção detectada (Polling O(1)/WAL)
    Agent->>Agent: Lê byte[] e mapeia para JSON
    Agent->>Redis: XADD (Stream: whatsapp_messages)
    Redis->>API: Signal (Consumer Group)
    API->>User: Output Real-time (Console/SignalR)

    Note over User, WA: Fluxo B: Inserção de Contatos
    User->>API: POST /contacts (JSON)
    API->>API: Valida Domain (DDD/Value Objects)
    API->>Redis: LPUSH (List: contact_queue)
    Redis->>Agent: BRPOP (Blocking Listen)
    Agent->>WA: content insert (Android Provider)
    Agent-->>API: ACK via Redis Hash (Opcional)```
