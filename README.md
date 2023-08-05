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
var config = new PicPayConfig
{
    BaseUrl = BaseUrl.ProductionEcommerce,
    Token = "your-token"
};

var client = new PicPayClient(config);
```
Para mais informação: [API Refence](https://picpay.github.io/picpay-docs-digital-payments/checkout/resources/api-reference)


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

var response = await client.Payment.CreateAsync(body);
```
## Capturar pagamento

```C#
var body = new PaymentRequest
{
    Amount= 12.04M
};

var response = await client.Payment.CaptureAsync(body, "102030");
```
## Cancelar pedido de pagamento
```C#
var body = new PaymentRequest
{
    AuthorizationId = "555008cef7f321d00ef236333",
    Amount= 50.05M
};

var referenceId = "102030";

var response = await client.Payment.CancelAsync(body, referenceId);
```

## Consultar Status do pedido
```C#
var referenceId = "102030";

var response = await client.Payment.StatusAsync(referenceId);
```