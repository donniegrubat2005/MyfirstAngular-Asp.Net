import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './services/employee.service';
import { NgForm} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createmployee',
  templateUrl: './createmployee.component.html',
  styleUrls: ['./createmployee.component.css']
})
export class CreatemployeeComponent implements OnInit {

  constructor(private service : EmployeeService, private route : Router) { }

  ngOnInit() {
   this.resetForm();
  }

  resetForm(form? : NgForm) {
    if(form !=null) 
    form.resetForm();
    this.service.formData= {
      empid: null,
      firstname: null,
      lastname: null,
      address: null
    }
  }

  onSubmit(form : NgForm) {
    console.log(form);
   this.insertRecord(form);
  }

  insertRecord(form : NgForm) {
  this.service.postEmployee(form.value)
  .subscribe(res => { 
  this.resetForm(form)
  this.route.navigate(['home']);
  });
  }

}
