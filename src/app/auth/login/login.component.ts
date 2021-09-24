import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      Password: '',
      Address: '',
    });
  }
  form: FormGroup;
  ngOnInit(): void {}

  login() {
    console.log(this.form.value.Address + ' ' + this.form.value.Password);
    this.router.navigateByUrl('pages');
  }
}
