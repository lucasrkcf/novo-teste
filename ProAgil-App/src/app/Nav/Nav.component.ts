import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({

  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService
    , public router: Router
    , private toastr: ToastrService) { }

  ngOnInit() {
  }
  loggedIn(){
    return this.authService.loggedIn();
  }

  entrar() {
    this.router.navigate(['/user/login']);
  }

  logout(){
    localStorage.removeItem('token');
    this.toastr.show('Log Out');
    this.router.navigate(['/user/login']);
  }
}
