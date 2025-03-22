# Wallet Service Documentation

## Overview
This document provides an overview of the Wallet service, including its API endpoints, domain models, and services.

## API Endpoints

### Transactions
#### Cash In
- **Endpoint:** `POST /api/v1/transactions/chash-in`
- **Request Body:**
  ```json
  {
    "walletId": 1,
    "amount": 1000,
    "description": "Deposit funds",
    "financialVoucherId": 12345
  }
  ```
- **Response:** `201 Created`

#### Cash Out
- **Endpoint:** `POST /api/v1/transactions/chash-out`
- **Request Body:**
  ```json
  {
    "walletId": 1,
    "amount": 500,
    "description": "Withdraw funds",
    "financialVoucherId": 54321
  }
  ```
- **Response:** `201 Created`

#### Swap
- **Endpoint:** `POST /api/v1/transactions/swap`
- **Request Body:**
  ```json
  {
    "sourceWalletId": 1,
    "destinationWalletId": 2,
    "sourceAmount": 500,
    "description": "Currency exchange",
    "financialVoucherId": 67890
  }
  ```
- **Response:** `201 Created`

### Wallets
#### Get Wallet Balance
- **Endpoint:** `GET /api/v1/wallets/{walletId}/balance`
- **Response:**
  ```json
  {
    "walletId": 1,
    "profileId": 123,
    "balance": 1500.00
  }
  ```

### Currencies
#### Create Currency
- **Endpoint:** `POST /api/v1/currencies`
- **Request Body:**
  ```json
  {
    "code": "USD",
    "name": "US Dollar",
    "ratio": 1.0
  }
  ```
- **Response:** `201 Created`

## Domain Models

### Currency
```csharp
public class Currency : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Ratio { get; set; }
    public DateTime ModifiedDateUtc { get; set; }
}
```

### Transaction
```csharp
public class Transaction : BaseEntity
{
    public int WalletId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionKind Kind { get; set; }
    public DateTime CreateDateUtc { get; set; }
    public int FinancialVoucherId { get; set; }
}
```

### UserWallet
```csharp
public class UserWallet : BaseEntity
{
    public int ProfileId { get; set; }
    public string Title { get; set; }
    public WalletStatus Status { get; set; }
    public string CurrencyCode { get; set; }
}
```

## Services

### Currency Service
Handles currency creation, updates, and retrieval.

### Transaction Service
Manages transactions including cash-in, cash-out, and swaps.

### Wallet Service
Retrieves wallet balances and manages user wallets.

## Event Subscription

### CreateProfileConsumer
Listens for `CreateProfileEvent` to create a default wallet for new users.

```csharp
public class CreateProfileConsumer : IConsumer<CreateProfileEvent>
{
    private readonly IWalletWriteRepository _walletWriteRepository;

    public async Task Consume(ConsumeContext<CreateProfileEvent> context)
    {
        var userWallet = new UserWallet()
        {
            ProfileId = context.Message.ProfileId,
            Status = WalletStatus.Active,
            Title = "DefaultWallet",
            CurrencyCode = "IRR"
        };

        await _walletWriteRepository.CreateWallet(userWallet);
    }
}
```

## DTOs

### CurrencyDto
```csharp
public record CurrencyDto(string Code, string Name, decimal Ratio);
```

### SwapDto
```csharp
public class SwapDto
{
    public int ProfileId { get; set; }
    public int SourceWalletId { get; set; }
    public int DestinationWalletId { get; set; }
    public int SourceAmount { get; set; }
    public string Description { get; set; }
    public int FinancialVoucherId { get; set; }
}
```

### WalletBalanceDto
```csharp
public class WalletBalanceDto
{
    public int WalletId { get; set; }
    public int ProfileId { get; set; }
    public decimal Balance { get; set; }
}
```

## Conclusion
This document provides a structured overview of the Wallet service, including API definitions, domain models, services, event subscriptions, and DTOs. This ensures a clean and maintainable implementation of the wallet system.

