import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  titulo = 'Login';
  model: any = {};

  constructor(public router: Router) { }

  ngOnInit() {
  }

  login() {
    console.log();
  }

}
