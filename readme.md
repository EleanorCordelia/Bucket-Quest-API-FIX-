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