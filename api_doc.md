# API Payment

This api has :

- RESTful endpoint for asset's CRUD operation
- JSON formatted response

Tech Stack used to build this app :

- ASP .Net
- MySQL

&nbsp;

### ==offline db(ubah connection string di file appsettings.json pada folder apiPayment)==
"ConnectionStrings": {
    "myconn": "Server=localhost;Database=Payment;Uid=root;Pwd=;SslMode=none",
},
### ==hosted db(ubah connection string di file appsettings.json pada folder apiPayment)===
"ConnectionStrings": {
    "myconn": "Server=sql6.freemysqlhosting.net;Database=sql6446040;Username=sql6446040;Pwd=EDm1dgBiLZ;SslMode=none"
}

## **Endpoints**

---
### url_Base(local db) : https://localhost:5001
### url_Base(hosted db) : https://apipayment.herokuapp.com

- `POST` /api/AuthManagement/Register
- `POST` /api/AuthManagement/Login
- `POST` /api/AuthManagement/RefreshToken
- `GET` /api/Payment
- `POST` /api/Payment
- `GET` /api/Payment/{id}
- `PUT` /api/Payment/{id}
- `DELETE` /api/Payment/{id}

## &nbsp;

### POST /api/AuthManagement/Register

> sign up a new user

> _Request Header_

```
not needed
```

_Request Body_

```
{
    "username": "string",
  "email": "string",
  "password: "string"
}
```

_Response (200 - Created)_

```
{
  "Thank you for your registration"
}
```

_Response (400 - Bad Request)_ => Validation Error

```
{
  "Invalid Payload"
}
```
---

### POST /api/AuthManagement/Login

> sign in user

> _Request Header_

```
{
  not needed
}
```

_Request Body_

```
{
  "email": "<User email>",
  "password: "<User Password>"
}
```

_Response (200 - OK)_

```
{
  "token": "<given by system>",
  "refreshToken": "<given by system>",
  "success": true,
  "errors": null
}
```

_Response (400 - Bad Request)_ 

```
{
  "Invalid login request"
}
```

### POST /api/AuthManagement/RefreshToken

> verify current token

> _Request Header_

```
not needed
```

_Request Body_

```
{
   "token": "<user current token>",
  "refreshToken": "<user current refresh token>",
  "success": true,
  "errors": null
}
```

_Response (200 - Created)_

```
{
  "token": null,
  "refreshToken": null,
  "success": false,
  "errors": [
    "Token has expired please re-login"
  ]
}
```

---

### GET /api/Payment

> Get all payment details

> _Request Header_

```
{
  "Authorization": "Bearer <your access token>"
}
```

_Request Body_

```
not needed
```

_Response (200 - OK)_

```
[
  { "paymentDetailId": 0,
    "cardOwnerName": "string",
    "cardNumber": "string",
    "expirationDate": "string",
    "securityCode": "string"
  }
]
```
---
### POST /api/Payment
> post(create) new payment detail

_Request Header_

```
{
  "Authorization": "Bearer <your access token>"
}
```
_Request Body_

```
{
  "cardOwnerName": "string",
  "cardNumber": "string",
  "expirationDate": "string",
  "securityCode": "string"
}
```
_Response(200-OK)_
```
{
    "Successfully create a new payment details, please check your database"
}
```
---

### GET /api/Payment/{id}

> get payment details by id

_Request Header_

```
{
  "Authorization": "Bearer <your access token>"
}
```

_Request Param_

```
{
  "id": "<payment details id>"
}
```

_Response (200 - OK)_

```
  { "paymentDetailId": 0,
    "cardOwnerName": "string",
    "cardNumber": "string",
    "expirationDate": "string",
    "securityCode": "string"
  }
```
---

### PUT /api/Payment/{id}

> Update/edit payment details with new data

_Request Header_

```
{
 "Authorization": "Bearer <your access token>"
}
```

_Request Body_

```
{
  "paymentDetailId": <payment detail id>,
  "cardOwnerName": "<new string>",
  "cardNumber": "<new string>",
  "expirationDate": "<new string>",
  "securityCode": "<new string>"
}
```

_Request Params_

```
{
    "id": "<payment details id>"
}
```

_Response (200 - OK)_

```
{
  "Successfully update selected payment details"
}
```

_Response (404 - Not Found)_

```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404,
  "traceId": "00-ed45d6b8496cc443a1b1b8b017ea21aa-02bf95fedcba5b44-00"
}
```
---

### DELETE /api/Payment/{id}

> Delete specific payment details by id

_Request Header_

```
{
  "Authorization": "Bearer <your access token>"
}
```

_Request Body_

```
not needed
```

_Request Params_

```
{
  "id": "<payment details id>"
}
```

_Response (200 - OK)_

```
{
  "Successfully delete selected payment details"
}
```

_Response (404 - Not Found)_

```
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "00-ed45d6b8496cc443a1b1b8b017ea21aa-02bf95fedcba5b44-00"
}
```
