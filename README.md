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

```.net cli
> dotnet add package PicPay
```

## Autenticando o ambiente e-commerce
```C#
var client = new PicPayClient(BaseUrl.ProductionEcommerce, "{seu_token}");
```

## Exemplo básico
Para mais detalhes: [API Refence](https://picpay.github.io/picpay-docs-digital-payments/checkout/resources/api-reference)
```C#
var request = new PicPayRequest<string>
{
    Body = "{seu json aqui ou seu objeto}",
    Method = Method.Get,
    Endpoint = "{seu_endpoint}"
};

var result = await client.ExecuteAsync(request);
```

## Criar pedido para pagamento

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
## Cancelar pedido de pagamento

```C#
var body = new PaymentRequest
{
    AuthorizationId = "555008cef7f321d00ef236333",
    Amount = 50.05M
};

var request = new PicPayRequest<PaymentRequest>
{
    Body = body,
    Method = Method.Post,
    Endpoint = "payments/102030/refunds"
};

var result = await client.ExecuteAsync(request);
```
## Consultar Status do pedido
```C#
var request = new PicPayRequest<object>
{
    Method = Method.Get,
    Endpoint = "payments/102030/status"
};

var result = await client.ExecuteAsync(request);
```

## Notificação de mudança no pedido

```C#
Estamos trabalhando
```