import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public fullName: string;
  public token: string

  constructor(protected http: HttpClient, private router: Router) { }

  login(username: string, password: string) {
    return this.http.post('/api/login/login', { username: username, password: password });
  }

  logout() {
    this.clearAuth();
    this.getAuth();
    this.router.navigate(['/']);
  }

  initAuth(username: string, token: string) {
    sessionStorage.setItem("token", token);
    sessionStorage.setItem("fullName", username.charAt(0).toUpperCase() + username.slice(1));
    this.token = token;
    this.fullName = username.charAt(0).toUpperCase() + username.slice(1);
    if (username == "user") {
      this.router.navigate(['/home']);
    }
    else if (username == "admin") {
      this.router.navigate(['/admin']);
    }
  }

  getAuth() {
    this.fullName = sessionStorage.getItem("fullName");
    this.token = sessionStorage.getItem("token");
  }

  clearAuth() {
    sessionStorage.clear();
  }
}
