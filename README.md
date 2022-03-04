
# Gringotts Bank

It is simple online banking API app. Gringotts Bank is a bank that has an online branch for wizards to do some account
transactions. Gringotts Bank is known for its goblin-made, secure, and consistent accounting
structure so account transaction consistency is the first priority for their operations.


## Run Project

Clone project

```bash
  git clone https://github.com/ukutluer/GringottsBank.API.git
```

Go to project folder

```bash
  cd project-folder
```

Run with docker compose

```bash
  docker-compose up -d
```


  
## API Usage


All API requests must have bearerToken for authorization. 
Only User/Register and User/Authenticate are not required for authorization.

Also all API responses returns json format of BaseGringottsBankResponse. 

#### User Register

```http
  POST /Users/Register
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Name` | `string` | **Required**. User name for register. |
| `Surname` | `string` | **Required**. User surname for register. |
| `Password` | `string` | **Required**. User password for register. |

#### Get all users

```http
  GET /Users
```


#### User Authenticate

```http
  POST /Users/Authenticate
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Name` | `string` | **Required**. User name for register. |
| `Password` | `string` | **Required**. User password for register. |




#### Get account details

```http
  GET /Account/{$accountId}
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `accountId` | `string` | **Required**. account id for details. |

#### Get user all accounts

```http
  GET /Account/
```


#### Add user account

```http
  POST /Account/add
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Currency` | `string` | Account currency. |




#### Get account transactions

```http
  GET /AccountTransaction/{$accountId}
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `accountId` | `string` | **Required**. account id for details. |


#### Add user account transaction

```http
  POST /AccountTransaction/AddUserAccountTransaction
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `AccountId` | `string` | **Required**.Account id |
| `TransactionAmount` | `decimal` | **Required**.Transaction amount |



#### Get user all accounts transactions

```http
  POST /AccountTransaction/GetUserAllAccountTransaction
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `StartDate` | `DateTime` |  **Required**. Start date |
| `EndDate` | `DateTime` |  **Required**. End date |





  
## Technologies

.Net Core, MongoDB, MongoExpress, Docker


  

[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
 