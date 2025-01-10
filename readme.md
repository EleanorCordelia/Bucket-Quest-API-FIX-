# API Documentation for BucketQuest📔

---

## Deskripsi

---

BucketQuest adalah platform B2C pihak ketiga yang menghubungkan traveler dengan berbagai layanan lokal untuk mewujudkan bucket list liburan impian. Melalui BucketQuest, pengguna bisa dengan mudah merencanakan perjalanan lengkap dari pemesanan jeep (wisata gunung), selimut, peralatan snorkeling dan diving (wisata pantai), jasa foto, hingga guide dan porter(naik gunung), dan lainnya. Mulai dari mendaki gunung, diving, snorkeling, memancing, hingga mencari teman perjalanan. Sehingga kalian tidak perlu lagi mencari informasi trip diving(or paket liburan lainnya) mana yang punya view tercantik dan worth it, tinggal sekali klik, semua jadi!

## Links

---

- 🔗[Website BucketQuest](https://shadcn-bucket-q.vercel.app/)
- 🔗[API Documentation Swagger](https://bucketquestapi.fly.dev/swagger)
- 🔗[Dokumen Laporan](https://docs.google.com/document/d/1LzBoLUOFgIyAsLhw8onxt2fC7WIekV9sXJSUVrL3bgM/edit?usp=sharing)
- 🔗[Repo Frontend](https://github.com/EleanorCordelia/Bucket-Quest.git)
- 🔗[Backend Link](https://bucketquestapi.fly.dev/swagger)

## Endpoints  

### 1. Get All Activities  
- **Method**: GET  
- **Path**: /api/Activity  
- **Description**: Mengambil semua data Tipe aktivitas yang tersedia.  

---

### 2. User Registration  
- **Method**: POST  
- **Path**: /api/Account/register  
- **Description**: Mendaftarkan pengguna baru.  

---

### 3. User Login  
- **Method**: POST  
- **Path**: /api/Account/login  
- **Description**: Mengautentikasi pengguna dan mengembalikan token akses.  

---

### 4. Single Sign-On (SSO)  
- **Method**: POST  
- **Path**: /api/Account/Sso  
- **Description**: Mengautentikasi pengguna melalui SSO (Google).  

---

### 5. Get All Bookings  
- **Method**: GET  
- **Path**: /api/Booking  
- **Description**: Mengambil semua data pemesanan.  

---

### 6. Create Booking  
- **Method**: POST  
- **Path**: /api/Booking  
- **Description**: Membuat pemesanan baru.  

---

### 7. Get All Packages  
- **Method**: GET  
- **Path**: /api/Package  
- **Description**: Mengambil semua paket yang tersedia.  

---

### 8. Search Packages  
- **Method**: GET  
- **Path**: /api/Package/search  
- **Description**: Mencari paket berdasarkan kriteria tertentu.  

---

### 9. Get Package by ID  
- **Method**: GET  
- **Path**: /api/Package/{id}  
- **Description**: Mengambil detail paket berdasarkan ID.  

## Headers

| Header Name     | Required | Description                      |
|------------------|----------|----------------------------------|
| Content-Type     | Yes      | application/json                 |
| Authorization    | Yes      | Bearer {token}                  |

## Authentication
API ini menggunakan token Bearer untuk autentikasi. Pastikan Anda memiliki token akses yang valid sebelum melakukan request.

## Error Handling 
API ini akan mengembalikan kode kesalahan berikut jika terjadi masalah:
* `400 Bad Request`: Permintaan tidak valid.
* `401 Unauthorized`: Token akses tidak valid atau tidak ada.
* `404 Not Found`: Endpoint tidak ditemukan.
* `500 Internal Server Error`: Terjadi kesalahan di server.

## Example Responses

# API Documentation

## User Log In

### Request Body
```json
{
  "email": "string",
  "password": "string"
}

```

### Success Response (201 Created)
```json
{
  "message": "Login berhasil",
  "token": "YOUR_JWT_TOKEN"
}
```

### Error Response (400 Bad Request)
```json
{
  "message": "Invalid credentials"
}

```

## Activity

### Success Response (200 OK)
```json
{
  "id": 1,
  "name": "Sample Activity"
}

```

## Booking

### Request Body
```json
{
  "contactName": "string",
  "contactEmail": "string",
  "contactPhone": "string",
  "packageId": 0,
  "participants": 0,
  "date": "string"
}

```

### Success Response (200 OK)
```json
{
  "id": 123,
  "contactName": "string",
  "contactEmail": "string",
  "contactPhone": "string",
  "packageId": 0,
  "participants": 0,
  "date": "string"
}
```

## Package

### Success Response (200 OK)
```json
[
  {
    "id": 1,
    "name": "Sample Package",
    "trips": [
      {
        "id": 1,
        "name": "Trip 1",
        "description": "Exciting Trip",
        "price": 100
      }
    ]
  }
]

```

## Package Search

### Query Parameters
**name**: string
**location**: string
**budget**: integer
**activity_type**: string
**participants**: integer

### Success Response (200 OK)

```json
[
  {
    "id": 1,
    "name": "Sample Package",
    "location": "Sample Location",
    "budget": 1000,
    "activity_type": "Adventure",
    "participants": 2
  }
]

```

## Package by ID

### Path Parameter
**id**: integer (required)

### Success Response (200 OK)

```json
{
  "id": 1,
  "name": "Sample Package",
  "trips": [
    {
      "id": 1,
      "name": "Trip 1",
      "description": "Exciting Trip",
      "price": 100
    }
  ]
}


```
