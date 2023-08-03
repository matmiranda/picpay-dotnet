[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)
![dotnet status](https://github.com/matmiranda/picpay-dotnet/actions/workflows/dotnet.yml/badge.svg?event=push)
[![NuGet Badge](https://buildstats.info/nuget/PicPay)](https://www.nuget.org/packages/PicPay)

## Índice - C#
- [Implementações .NET com suporte](#implementações-net-com-suporte)
- [Instalação](#instalação)
- [Autenticando](#autenticando-o-ambiente-e-commerce)
- [Pagamento](#pagamento)
  - [Requisição Pagamento](#requisição-pagamento)
  - [Cancelamento](#cancelamento)
  - [Status](#status)
- [Notificação](#notificação)
  - [Criar notificação](#criar-notificação)
- [Tabela](#tabela)
  -[Status Code](#status-code)

## Implementações .NET com suporte
A biblioteca foi feito em **[.NET Standard 2.1](https://learn.microsoft.com/pt-br/dotnet/standard/net-standard?tabs=net-standard-2-1) e  VS2022**

## Instalação
Execute o comando para instalar via [NuGet](https://www.nuget.org/packages/PicPay/):

```xml
PM> Install-Package PicPay
```

## Autenticando o ambiente e-commerce
```C#
var client = new PicPayClient(BaseUrl.ProductionEcommerce, "{seu_token}");
```

## Exemplo básico
```C#
var request = new PicPayRequest<string>
{
    Body = "{seu json aqui ou seu objeto}",
    Method = Method.Get,
    Endpoint = "{seu_endpoint}"
};

var result = await client.ExecuteAsync(request);
```

## Pagamento
#### Requisição Pagamento
Para mais detalhes: [API Refence](https://picpay.github.io/picpay-docs-digital-payments/checkout/resources/api-reference)

```C#
var body = new PaymentRequest
{
    ReferenceId = "102030",
    CallbackUrl = "http://www.sualoja.com.br/callback",
    ReturnUrl = "http://www.sualoja.com.br/cliente/pedido/102030",
    Value = 20.51M,
    Buyer = new Buyer
    {
        FirstName = "João",
        LastName = "Da Silva",
        Document = "123.456.789-10",
        Email = "test@picpay.com",
        Phone = "+55 27 12345-6789"
    }
};

var request = new PicPayRequest<PaymentRequest>
{
    Body = body,
    Method = Method.Post,
    Endpoint = "{seu_endpoint}"
};

var result = await client.ExecuteAsync(request);
```
#### Cancelamento
Link: https://ecommerce.picpay.com/doc/#operation/postCancellations
```C#
PaymentRequest body = new PaymentRequest
{
    AuthorizationId = "555008cef7f321d00ef236333"
};
var result = await PP.Payment.Cancel(body, "102030");
```
#### Status
Link: https://ecommerce.picpay.com/doc/#operation/getStatus
```C#
var result = await PP.Payment.Status("102030");
```

## Notificação
#### Criar notificação
Link: https://ecommerce.picpay.com/doc/#operation/postCallbacks
```C#
var body = new NotificationRequest
{
    ReferenceId = "102030",
    AuthorizationId = "555008cef7f321d00ef236333"
};
var url = "http://www.sualoja.com.br/callback";
var result = await PP.Notification.Create(body, "4ef4edbd-5cda-42da-860b-0e8d7b90c784", url);
```

## Tabela
#### Status Code

| Código  | Status | Descrição |
| ------------- | ------------- | -- |
| 200  | OK  | Equivalente ao status HTTP 200. OK indica que a solicitação foi bem-sucedida e que as informações solicitadas estão na resposta. Este é o código de status mais comuns a ser recebido.
| 401 | Unauthorized  | Equivalente ao status HTTP 401. Unauthorized indica que o recurso solicitado requer autenticação. O cabeçalho WWW-Authenticate contém os detalhes de como realizar a autenticação. |
| 422 | UnprocessableEntity | Equivalente ao status HTTP 422. UnprocessableEntity indica que o servidor entende o tipo de conteúdo da entidade de solicitação e a sintaxe da entidade de solicitação está correta, mas não conseguiu processar as instruções contidas.
| 500 | InternalServerError | Equivalente ao status HTTP 500. InternalServerError indica que ocorreu um erro genérico no servidor. |

Exemplo:
```C#
var result = await PP.Payment.Status("102030");
var code = result.StatusCode;
```

Lista de códigos de estado HTTP: [HTTP Status Codes](https://pt.wikipedia.org/wiki/Lista_de_c%C3%B3digos_de_estado_HTTP) 👈
