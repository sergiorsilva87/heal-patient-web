# Portal do Paciente — Backlog por Bounded Context

> Este arquivo consolida as features discutidas para o Portal do Paciente, organizadas por Bounded Context responsável.
> Novas features identificadas em discussões futuras devem ser adicionadas à seção do BC correspondente.

---

## BC-PLT-01 — IdentityContext

Responsável por autenticação, sessões e permissões — inclusive para o acesso especial (sem login) do paciente no portal.

- [ ] Registrar evento quando o paciente **visualiza o laudo** (`PatientReportViewed`)
- [ ] Registrar evento quando o paciente **acessa o fluxo de download do laudo/PDF** (`PatientReportDownloadRequested`)
- [ ] Registrar evento quando o paciente **visualiza imagens do exame** (`PatientImagesViewed`)
- [ ] Registrar evento quando o paciente **imprime imagens do exame** (`PatientImagesPrinted`)
- [ ] Padronizar payload de auditoria com: `TenantId`, `PatientId`, `AccessionNumber`, `ReportId/StudyInstanceUid`, `TimestampUtc`, `SourceIp`, `UserAgent`
- [ ] Definir política de retenção e consulta operacional da trilha de auditoria para o portal do paciente

- [ ] Gerar **sessão temporária** para o paciente ao acessar o portal (sem conta, sem senha)
- [ ] Definir **tempo de expiração** da sessão temporária do paciente

- [ ] Persistir preferência de tamanho de fonte do portal do paciente (`fontScale`) por usuário/sessão
- [ ] Definir limites de acessibilidade para ajuste de fonte (mín/máx) e comportamento padrão por tenant
- [ ] Permitir reset de preferências de acessibilidade para o padrão do tenant

---

- [ ] Revogar sessão temporária após o tempo limite ou acesso encerrado
- [ ] Garantir que a sessão do paciente está **vinculada ao tenant** resolvido pelo subdomínio — impedindo acesso cross-tenant
- [ ] Definir **permissões mínimas** para a sessão do paciente: somente leitura, somente seus próprios exames, sem acesso a dados de outros pacientes

- [ ] Mapear e disponibilizar para o portal os metadados DICOM de equipe e execução: médico executor, CRM/UF (quando existir), técnico de radiologia e registro/UF
- [ ] Mapear dados de procedência do exame: unidade de realização, número de acesso (Accession Number), data do exame
- [ ] Mapear dados clínicos adicionais do estudo/procedimento quando houver no DICOM/integração
- [ ] Definir estratégia para ausência de CRM/UF do médico solicitante no DICOM (fallback "não informado")
- [ ] Registrar auditoria da sessão (início, expiração, ações realizadas)

- [ ] Exibir no portal dados completos do paciente e do exame para conferência segura: nome, ID do paciente, data de nascimento, número de acesso, protocolo, procedimento, data do exame e data do laudo
- [ ] Exibir dados da equipe assistencial no portal: médico executor + CRM/UF, médico solicitante (+ CRM/UF quando disponível), técnico de radiologia + registro/UF
- [ ] Exibir unidade onde o exame foi realizado
- [ ] Organizar ações no card do exame por objetivo (Laudo, Imagens, Compartilhar) para reduzir carga cognitiva
- [ ] Exibir status clínico explícito e orientativo por exame (ex.: "Pronto para laudo", "Imagens disponíveis", "Em processamento")
- [ ] Separar lista de exames em "Mais recentes" e "Anteriores", com ordenação padrão por data decrescente

- [ ] Armazenar configuração de **conta de e-mail SMTP** por tenant (host, porta, usuário, senha, remetente padrão, TLS/SSL)

### Usabilidade e acessibilidade do Portal do Paciente

- [ ] Ajustar topo mobile para manter ajuda/idioma/ações secundárias acessíveis sem poluição visual
- [ ] Exibir idioma atual de forma explícita no menu (opcional: bandeira por idioma)
- [ ] Incluir controles de acessibilidade no topo para aumentar/diminuir fonte
- [ ] Garantir legibilidade ampliada (font-size, line-height, espaçamento entre blocos)
- [ ] Melhorar contraste visual de elementos informativos para nível AA
- [ ] Corrigir alinhamento vertical de texto em botões do cabeçalho (ex.: Ajuda)
- [ ] Ajustar espaçamento e hierarquia visual entre seções da lista de exames (ex.: "Anteriores")
- [ ] Melhorar feedback de erro de formulário com linguagem simples e orientativa
- [ ] Exibir ajuda contextual em pontos críticos (login e lista de exames)
- [ ] Armazenar URL dos **Termos e Condições** do portal por tenant — exibido no banner de cookies e no rodapé
- [ ] Armazenar URL da **Política de Privacidade / Cookies** por tenant
- [ ] Configurar **conteúdo do menu de ajuda** por tenant: texto de introdução, perguntas frequentes (FAQ) e dados de contato da clínica/hospital (telefone, e-mail de suporte, horário de atendimento)
- [ ] Configurar **idioma padrão** do portal por tenant (PT-BR, ES ou EN)

---

## BC-PLT-03 — PatientContext

Responsável pelo cadastro e dados do paciente compartilhados entre módulos.

- [ ] Armazenar **CPF** do paciente como identificador alternativo de acesso ao portal
- [ ] Armazenar **e-mail** do paciente (quando disponível) para notificações
- [ ] Expor consulta de paciente por CPF (usada pelo fluxo de acesso alternativo ao portal)

---

## BC-COR-01 — ReportingContext

Responsável pela criação, revisão, assinatura e ciclo de vida do laudo médico.

### Imutabilidade do laudo

- [ ] Laudo concluído é **imutável** — nenhuma edição é permitida após a conclusão, nem pelo próprio médico autor
- [ ] Qualquer tentativa de edição em laudo concluído deve ser rejeitada com erro explícito

### Assinatura digital

- [ ] Quando o tenant tiver **assinatura ICP-Brasil habilitada** (BC-PLT-02), exigir assinatura digital A3 + carimbo de tempo TSA para concluir o laudo
- [ ] Quando o tenant **não exigir ICP-Brasil**, permitir conclusão do laudo sem assinatura digital certificada
- [ ] Registrar no laudo qual modalidade de conclusão foi utilizada (`SignedICP` ou `Unsigned`)

### Adendos ao laudo

- [ ] Permitir que o médico adicione um **adendo** a um laudo já assinado
- [ ] Adendo é um documento complementar independente, vinculado ao laudo original — nunca sobrescreve o conteúdo original
- [ ] Adendo segue a mesma regra de assinatura do laudo original: **ICP-Brasil quando exigido pelo tenant**, sem assinatura certificada caso contrário
- [ ] Um laudo pode ter **múltiplos adendos** ao longo do tempo
- [ ] Adendos são exibidos em ordem cronológica após o corpo do laudo original
- [ ] Registrar evento `ReportAddendumPublished` ao concluir e assinar um adendo
- [ ] Adendo publicado deve acionar entrega atualizada ao paciente e ao médico solicitante (via DeliveryContext e NotificationContext)

---

## BC-SUP-02 — DeliveryContext

Responsável pela entrega do resultado ao paciente e ao médico solicitante — controla as formas de acesso ao portal.

### Acesso primário (Accession Number + data de nascimento)

- [ ] Validar acesso ao portal via **Accession Number (número de protocolo)** + **data de nascimento**
- [ ] Tratar ausência de Accession Number no DICOM: sinalizar o exame como sem protocolo e bloquear acesso primário, ativando fluxo alternativo

### Acesso alternativo (CPF + código temporário)

- [ ] Permitir que a **recepção** ou o **técnico de radiologia** (quando o exame estiver concluído) solicite a geração de um **código de acesso temporário** de 6 ou 8 dígitos
- [ ] Gerar o código de forma **aleatória e segura** (não sequencial, não previsível)
- [ ] Associar o código ao par `(paciente, exame, tenant)` com **prazo de validade fixo de 30 dias** a partir da geração
- [ ] Validar acesso ao portal via **CPF** + **código temporário**
- [ ] Invalidar o código automaticamente após 30 dias
- [ ] Permitir que a recepção/técnico **gere um novo código** a qualquer momento — o novo código reinicia o prazo de 30 dias e invalida o código anterior
- [ ] Registrar histórico de geração de códigos (quem gerou, quando, se foi substituído)

### Token de sessão

- [ ] Emitir **token de sessão temporário** após qualquer validação bem-sucedida (primária ou alternativa), entregue ao IdentityContext para criação da sessão

### Entrega do resultado

- [ ] Disponibilizar laudo assinado para visualização no portal após publicação (`ReportPublished`)
- [ ] Disponibilizar **adendos** ao laudo no portal, em ordem cronológica após o corpo do laudo original, ao receber `ReportAddendumPublished`
- [ ] Disponibilizar imagens do exame para visualização no portal via **DWV (DICOM Web Viewer)** — viewer zero-footprint, sem instalação, funciona em qualquer navegador (GPL-3.0)
- [ ] Permitir **impressão das imagens do exame** diretamente pelo portal via DWV — layout de impressão otimizado para papel com identificação do paciente e do exame
- [ ] Gerar **QR Code** vinculado ao resultado do exame

### Download de laudo — tratamento de armazenamento frio (cold storage)

- [ ] Identificar se o arquivo do laudo está em **armazenamento frio** (cold storage) antes de iniciar o download
- [ ] Se estiver em cold storage, **não bloquear nem exibir erro técnico** — exibir mensagem amigável ao paciente informando que o laudo não está disponível imediatamente por ser um exame mais antigo, que a solicitação foi registrada e que o status será atualizado assim que o arquivo estiver pronto
- [ ] Registrar a solicitação de recuperação como um **pedido em fila** com status `PendingRetrieval`
- [ ] Atualizar o status do pedido para `Available` quando o arquivo for recuperado do cold storage
- [ ] Se o e-mail do paciente estiver cadastrado **e** o tenant tiver e-mail configurado corretamente (BC-PLT-02), notificar o paciente via e-mail quando o download estiver disponível (via NotificationContext)
- [ ] Exibir no portal o **status da solicitação** de forma clara e não técnica (ex.: "Seu laudo está sendo preparado", "Seu laudo está pronto para download")
- [ ] PDF do laudo deve incluir o laudo original e todos os adendos existentes

---

## BC-GEN-01 — NotificationContext

Responsável pelo disparo de notificações (e-mail, SMS) a pacientes e médicos.

- [ ] Notificar o paciente por **e-mail** quando o laudo estiver disponível, usando a configuração SMTP do tenant (BC-PLT-02)
- [ ] Notificar o paciente por **SMS** quando o laudo estiver disponível
- [ ] Notificar o paciente por e-mail e/ou SMS quando um **adendo** for adicionado ao laudo (`ReportAddendumPublished`)
- [ ] Verificar se o paciente possui e-mail cadastrado antes de tentar o disparo — consultar PatientContext (e-mail direto) e PEP EncounterContext (e-mail vindo do prontuário), quando o módulo PEP estiver ativo
- [ ] Notificar o paciente por e-mail com o **código de acesso temporário** quando gerado pela recepção/técnico (fluxo alternativo) — incluindo data de validade de 30 dias na mensagem
- [ ] Notificar o paciente por e-mail quando o download de um laudo em **cold storage** estiver disponível, desde que e-mail cadastrado e SMTP configurado no tenant
- [ ] Registrar falhas de disparo e prever reenvio

---

## Portal Web App — Funcionalidades transversais

Funcionalidades de UX/UI do portal do paciente que não pertencem a um único BC de domínio.

### Consentimento de cookies e termos

- [ ] Exibir **banner de consentimento de cookies** na primeira visita, com link para Termos e Condições e Política de Privacidade configurados pelo tenant (BC-PLT-02)
- [ ] Registrar o consentimento do paciente (aceite + timestamp) em conformidade com a LGPD
- [ ] Impedir rastreamento não essencial antes do aceite

### Menu de ajuda

- [ ] Exibir **menu de ajuda** acessível em todas as páginas do portal
- [ ] Conteúdo do menu carregado da configuração do tenant (BC-PLT-02): FAQ, contato da clínica, horário de atendimento
- [ ] Exibir instruções padrão da plataforma para tenants que não configuraram conteúdo próprio

### Internacionalização (i18n)

- [ ] Suportar **PT-BR** (padrão), **Espanhol (ES)** e **Inglês (EN)** em todas as telas do portal
- [ ] Detectar idioma automaticamente pelo navegador do paciente
- [ ] Permitir que o paciente troque o idioma manualmente
- [ ] Idioma padrão configurável por tenant (BC-PLT-02) — sobrepõe a detecção automática quando definido
- [ ] Todas as mensagens de status, erros e notificações exibidas ao paciente devem ser traduzíveis

---

## BC-PEP-01 — EncounterContext _(módulo PEP — opcional)_

Responsável pelo atendimento clínico. Relevante para o portal quando o módulo PEP estiver contratado.

- [ ] Expor e-mail do paciente registrado no prontuário para uso pelo NotificationContext
- [ ] Garantir que o e-mail só é exposto ao NotificationContext do mesmo tenant (isolamento por tenant)
