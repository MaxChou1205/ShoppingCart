import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../../core/services/user.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  @ViewChild(NgForm, { static: false, }) form: NgForm;

  username: string;
  pwd: string;
  errorMessage: string;

  constructor(private userService: UserService) {
    userService.clearAuth();
  }

  login() {
    let valid = this.form.valid;
    if (valid) {
      this.userService.login(this.username, this.pwd).subscribe(
        (res: any) => {
          this.userService.initAuth(this.username, res.token);
        }, (error: HttpErrorResponse) => {
          if (error.status == 401)
            this.errorMessage = "Invalid username or password.";
        });
    }
    else {
      this.errorMessage = 'Please fill up username and password.'
    }
  }

  ngOnInit() {
  }

}
