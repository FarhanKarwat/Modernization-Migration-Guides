# Web Forms → API + SPA Mapping

| Web Forms Page/Event                | API (Controller/Action)                 | SPA Route / Component              |
|------------------------------------|-----------------------------------------|------------------------------------|
| `Default.aspx` (list users)        | `GET /api/users`                        | `/users` (UsersListComponent)      |
| `AddUser_Click` (button postback)  | `POST /api/users`                       | `POST via UsersService.add(name)`  |
| `Delete Row`                       | `DELETE /api/users/{id}`                | Trash icon → service.delete(id)    |

### Notes
- Postbacks become **explicit HTTP methods** (GET/POST/DELETE).
- ViewState-bound data becomes **client state** in SPA.
- Server controls → HTML + Angular components.
