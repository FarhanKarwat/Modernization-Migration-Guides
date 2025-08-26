# Angular Client (Skeleton)

This folder is a placeholder to help you scaffold an Angular app and connect to the ModernizedApi.

## Scaffold Angular 17+
```bash
npm install -g @angular/cli
ng new modern-client --routing --style=scss
cd modern-client
ng serve
```

## Call the API
Create a simple service:
```ts
// src/app/users.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class UsersService {
  base = 'http://localhost:5178/api/users';
  constructor(private http: HttpClient) {}
  get() { return this.http.get<any[]>(this.base); }
  add(name: string) { return this.http.post(this.base, { name }); }
  delete(id: number) { return this.http.delete(`${this.base}/${id}`); }
}
```

Add HttpClientModule in `app.module.ts`, inject `UsersService` in a component, and bind to a simple UI.

> CORS is enabled in the API for `http://localhost:4200`.
