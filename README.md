# Portal do Paciente - White Label

## O que é o Portal do Paciente?

O Portal do Paciente é o espaço digital onde qualquer pessoa que realizou um exame de imagem (raio-X, tomografia, ressonância, ultrassom, mamografia etc.) pode consultar seus resultados de forma simples, segura e sem precisar ir pessoalmente à clínica.

Cada clínica ou hospital que usa a plataforma tem o seu próprio portal, com a identidade visual (logotipo, cores) da própria instituição — por isso é chamado de **white-label**: o paciente acessa um endereço que parece ser da clínica onde foi atendido, não da plataforma que a tecnologia usa por trás.

---

## Features

### Acesso sem senha

- O paciente acessa o portal informando o **número de protocolo do exame** e a **data de nascimento** sem necessidade de criar conta ou lembrar senha.
- Internamente o acesso é protegido por um **token temporário** gerado automaticamente quando o laudo fica disponível, garantindo segurança sem burocracia.

### Acesso alternativo por CPF e código

- Quando o exame não possui número de protocolo, a recepção ou o técnico de radiologia pode gerar um **código de acesso** para o paciente.
- O código tem validade de **30 dias** e o paciente acessa o portal informando seu **CPF** + o código recebido.
- Caso o código expire ou o paciente não o tenha recebido, a recepção pode gerar um novo código a qualquer momento — o novo prazo de 30 dias começa a contar do zero.

### Visualização do laudo médico

- Leitura do **laudo médico** diretamente no navegador, sem necessidade de instalar nenhum programa.
- O laudo exibe **cabeçalho e rodapé institucionais** com dados da clínica/hospital (identificação e contato), mantendo o padrão documental.
- Quando a clínica ou hospital exige, o laudo é **assinado digitalmente com certificado ICP-Brasil**, conferindo validade jurídica plena. Essa exigência é configurável — nem todas as instituições precisam desse nível de assinatura.
- Um laudo nunca é alterado após a assinatura. Caso o médico precise complementar alguma informação, ele inclui um **adendo** — um texto adicional exibido logo abaixo do laudo original, em ordem cronológica. O conteúdo original permanece intacto e visível.
- Cada adendo exibe seus metadados de autoria e rastreabilidade: **data do adendo**, **nome do médico que adicionou**, **CRM** e **UF do CRM**.
- A tela do laudo também pode listar os **anexos do exame (0..n)** com download individual por arquivo.
- Quando um adendo é publicado, o paciente recebe uma notificação (por e-mail e/ou SMS, se configurado) informando que há uma atualização no seu resultado.

### Download do laudo em PDF

- O paciente pode baixar o laudo em formato PDF para guardar, enviar ao médico solicitante ou apresentar em outra consulta.
- Laudos mais antigos podem não estar disponíveis imediatamente para download. Nesses casos, o portal exibe uma mensagem amigável explicando que o arquivo está sendo recuperado e que o download ficará disponível em breve — sem mensagens técnicas ou de erro. O próprio portal atualiza o status da solicitação ("Seu laudo está sendo preparado" → "Seu laudo está pronto para download") e, se a clínica tiver e-mail configurado e o paciente tiver e-mail cadastrado, ele também recebe uma notificação quando estiver pronto.

### Download de anexos do exame (0..n)

- Na mesma tela de download do laudo, o portal também exibe os arquivos anexados pela equipe da clínica (recepção, técnico de radiologia ou auxiliar de sala).
- Os anexos são apresentados em tabela com: data/hora do anexo, nome do arquivo, nome de quem anexou, perfil/role e ação de download.
- O portal exibe um ícone visual coerente com o tipo de arquivo (ex.: PDF, Word, imagem), facilitando identificação rápida pelo paciente.

### Visualização das imagens médicas

- As imagens do exame (raio-X, tomografia, ressonância etc.) podem ser visualizadas diretamente no navegador, sem instalar software adicional.
- O visualizador utilizado é o **DWV (DICOM Web Viewer)** — leve, zero-footprint e funciona inclusive em conexões de internet mais lentas.

### Impressão das imagens do exame

- O paciente pode **imprimir as imagens do exame** diretamente pelo portal, sem precisar instalar nenhum programa.
- A impressão é otimizada para papel, exibindo as imagens em layout adequado com identificação do paciente e do exame.

### QR Code para compartilhamento

- O portal gera um **QR Code** vinculado ao resultado do exame, facilitando o compartilhamento com médicos ou o acesso rápido pelo celular.

### Notificação automática por e-mail e SMS

- Quando o laudo fica disponível, o paciente pode receber automaticamente uma **notificação por e-mail e/ou SMS** com o link para acessar os resultados.
- Esse envio é **configurável pela clínica ou hospital** — a instituição define se ativa as notificações e fornece as credenciais do serviço de e-mail (SMTP ou provedor como SendGrid). Sem essa configuração, o portal funciona normalmente, mas sem o envio automático.

### Identificação automática da clínica pelo subdomínio

- O sistema identifica automaticamente qual clínica ou hospital está sendo acessado com base no **subdomínio da URL**, sem que o paciente precise informar nada.
- Cada clínica recebe um subdomínio exclusivo gerenciado pela plataforma — por exemplo, `clinica-abc.whitemage.com.br`.
- Isso garante que os dados exibidos são sempre e somente os da clínica correta, sem risco de cruzamento de informações entre instituições diferentes.

### Identidade visual da clínica (white-label)

- O portal é acessado pelo subdomínio exclusivo da clínica (por exemplo, `clinica-abc.whitemage.com.br`), com a logomarca e as cores da instituição.
- O paciente tem a experiência de estar no ambiente digital da clínica onde foi atendido.

### Consentimento de cookies e termos

- Ao acessar o portal pela primeira vez, o paciente vê um **aviso de cookies** com link para os Termos e Condições e a Política de Privacidade da clínica ou hospital.
- O aceite é registrado em conformidade com a **LGPD** — nenhum dado de rastreamento não essencial é coletado antes do consentimento.

### Menu de ajuda

- O portal oferece um **menu de ajuda** acessível em todas as páginas, com orientações sobre como usar o portal, perguntas frequentes e dados de contato da clínica ou hospital.
- O conteúdo da ajuda é configurável por cada instituição.

### Usabilidade e acessibilidade (foco no paciente)

- O layout foi ajustado para leitura mais confortável, especialmente para público 50+, com melhor contraste, maior legibilidade e espaçamento entre blocos.
- O menu superior possui botões para **aumentar/diminuir fonte** (`A+` e `A-`), com preferência salva no navegador do paciente.
- O portal inclui melhorias de acessibilidade baseadas em WCAG, como foco visível por teclado, áreas de toque maiores e navegação com menos ruído visual no mobile.
- O topo mobile foi ajustado para manter ações secundárias (ajuda, idioma e saída) acessíveis sem poluir a tela.

### Dados clínicos detalhados do exame

- O portal exibe metadados clínicos ampliados no painel de exame e no laudo:
	- nome do paciente, ID do paciente, data de nascimento e número de acesso;
	- número de protocolo, tipo, procedimento, data do exame e data do laudo;
	- unidade onde o exame foi realizado;
	- médico executor com CRM e UF do CRM;
	- médico solicitante;
	- técnico de radiologia, registro profissional e UF do registro.
- Sobre o médico solicitante: quando o CRM/UF não estiver disponível na origem DICOM, o portal exibe como **não informado**.
- Para técnico de radiologia, foi adotada a nomenclatura de registro **CRTR** (Conselho Regional de Técnicos em Radiologia), conforme uso comum no contexto brasileiro.

### Rastreabilidade de interação do paciente (auditoria)

- O portal registra eventos de navegação relevantes para auditoria e acompanhamento de uso:
	- quando o paciente **visualiza o laudo**;
	- quando **acessa o fluxo de download do laudo (PDF)**;
	- quando **visualiza as imagens do exame**;
	- quando **imprime as imagens do exame**.
- Cada evento é registrado com timestamp, protocolo e contexto da navegação.

### Suporte a múltiplos idiomas

- O portal está disponível em **Português (PT-BR)**, **Espanhol** e **Inglês**.
- O idioma é detectado automaticamente pelo navegador do paciente, podendo ser alterado manualmente a qualquer momento.
- A clínica ou hospital pode definir um idioma padrão para o seu portal.

### Diretrizes de tradução (.resx)

- O padrão de tradução do Portal do Paciente deve usar **chave = texto em português (PT-BR)**.
- Assim, se uma tradução específica de outro idioma estiver ausente, o fallback exibido na interface continua em português legível.
- Exemplo recomendado:
	- Chave PT-BR: `Olá {0} meus parabéns!`
	- Valor EN: `Hello {0} congratulations!`
	- Valor ES: `Hola {0} felicitaciones!`
- Sempre que houver texto dinâmico, usar interpolação posicional (`{0}`, `{1}`, ...).
- Evitar chaves técnicas (`HomeTitle`, `BtnSubmit`, etc.). A chave deve ser o próprio texto em português que aparece na tela.

### Privacidade e segurança (LGPD)

- Todos os dados do paciente são armazenados de forma isolada por clínica — um paciente de uma clínica nunca tem acesso a dados de outra.
- O sistema está em conformidade com a **Lei Geral de Proteção de Dados (LGPD)** e com as normas do **CFM** (Conselho Federal de Medicina) e **ANVISA**.
- A comunicação é criptografada (TLS/HTTPS) e os tokens de acesso expiram automaticamente.
