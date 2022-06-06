import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup( {
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private dataService: DataService,
    private router: Router,
    private messageService: MessageService
  ) { }

  get username(): AbstractControl {
    return this.loginForm.get('username') as AbstractControl;
  }

  get password(): AbstractControl {
    return this.loginForm.get('password') as AbstractControl;
  }

  ngOnInit(): void {
  }

  public login(): void {
    console.log(this.loginForm.value);
    this.dataService.changeUserData(this.loginForm.value);
    
    localStorage.setItem('Role', 'Admin');
    this.messageService.add('Authorized!');
    this.router.navigate(['/dashboard']);
  }

}
