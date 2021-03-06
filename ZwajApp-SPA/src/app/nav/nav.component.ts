import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { NEXT } from '@angular/core/src/render3/interfaces/view';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  constructor(private authService:AuthService) { }

  ngOnInit() {
  }

  login(){
    // console.log(this.model)
    this.authService.login(this.model).subscribe(
      next=>{console.log('تم الدخول بنجاح')},
      // error=>{console.log('فشل في الدخول')}
      error=>{console.log(error)}
    )
  }

loggedIn(){
  const token=localStorage.getItem('token');
  return !! token
}

loggedOut(){
  localStorage.removeItem('token');
  console.log('تم الخروج')
}
}
