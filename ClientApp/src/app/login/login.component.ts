import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular'


@Component({
  selector: 'login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
 
  //constructor(public auth: AuthService) {
    
  //}
    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }
}
