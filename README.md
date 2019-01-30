<p align="center">
  <a href="https://dev.wirecard.com.br/v2.0/">
    <img src="https://res.cloudinary.com/matmiranda/image/upload/v1548888382/PicPay%20%2B%20.NET.jpg" alt="Wirecard logo" width=400>
  </a>
</p>
<p align="center">
    O jeito mais simples e rápido de integrar o PicPay a sua aplicação .NET e feito com base nas APIs REST do PicPay.
  <br>
  <br>
    <a href="https://ecommerce.picpay.com/doc/">
        <img src="https://img.shields.io/badge/Docs-PicPay-orange.svg"
            alt="Docs"></a>
    <a href="https://github.com/matmiranda/PicPay-NET/blob/master/LICENSE">
        <img src="https://img.shields.io/badge/License-MIT-brightgreen.svg"
            alt="MIT"></a>
    <a href="https://www.nuget.org/packages/PicPay">
        <img src="https://img.shields.io/badge/Nuget-v1.0.0-blue.svg"
            alt="NuGet"></a>
</p>

## Índice - C#
- [Implementações .NET com suporte](#implementações-net-com-suporte)
- [Instalação](#instalação)
- [Autenticando](#autenticando-o-ambiente-e-commerce)
- [Pagamento](#pagamento)
  - [Requisição Pagamento](#requisição-pagamento)
  - [Cancelamento](#cancelamento)
  - [Status](#status)


## Implementações .NET com suporte
Essa biblioteca foi feito em (**.NET Standard 2.0 e VS2017**) e tem suporte das seguintes implementações do .NET:

* .NET Core 2.0 ou superior
* .NET Framework 4.6.1 ou superior
* Mono 5.4 ou superior
* Xamarin.iOS 10.14 ou superior
* Xamarin.Mac 3.8 ou superior
* Xamarin.Android 8.0 ou superior
* Universal Windows Platform 10.0.16299 ou superior

Para mais informações: [.NET Standard](https://docs.microsoft.com/pt-br/dotnet/standard/net-standard).

## Instalação
Execute o comando para instalar via [NuGet](https://www.nuget.org/packages/PicPay/):

```xml
PM> Install-Package PicPay
```

## Autenticando o ambiente e-commerce
```C#
PicPayClient PP = new PicPayClient("5b008cef7f321d00ef2367b2");
```

## Pagamento
Seu e-commerce irá solicitar o pagamento de um pedido através do PicPay na finalização do carrinho de compras. Após a requisição http, o cliente deverá ser redirecionado para o endereço informada no campo paymentUrl para que o mesmo possa finalizar o pagamento.

Assim que o pagamento for concluído o cliente será redirecionado para o endereço informada no campo returnUrl do json enviado pelo seu e-commerce no momento da requisição. Se não informado, nada acontecerá (o cliente permanecerá em nossa página de checkout).

Caso seja identificado que seu cliente também é cliente PicPay, iremos enviar um push notification e uma notificação dentro do aplicativo PicPay avisando sobre o pagamento pendente. Para todos os casos iremos enviar um e-mail de pagamento pendente contendo o link de nossa página de checkout.
#### Requisição de Pagamento

```C#
PaymentRequest body = new PaymentRequest
{
    ReferenceId = "102030",
    CallbackUrl = "http://www.sualoja.com.br/callback",
    ReturnUrl = "http://www.sualoja.com.br/cliente/pedido/102030",
    Value = 20.51,
    Buyer = new Buyer
    {
        FirstName = "João",
        LastName = "Da Silva",
        Document = "123.456.789-10",
        Email = "test@picpay.com",
        Phone = "+55 27 12345-6789"
    }
};
var result = await PP.Payment.Create(body);
```
#### Cancelamento
```C#
PaymentRequest body = new PaymentRequest
{
    AuthorizationId = "555008cef7f321d00ef236333"
};
var result = await PP.Payment.Cancel(body, "102030");
```
#### Status
```C#
var result = await PP.Payment.Status("102030");
```
