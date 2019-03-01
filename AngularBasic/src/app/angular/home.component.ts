import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from './services/employee.service';
import { Employee } from './models/employee.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  // @Input() employee: Employee;

  constructor(private _router: Router, 
    private service: EmployeeService,
    private _route : ActivatedRoute) { }

  onLogout() {
    this._router.navigate(['login']); 
  }

  ngOnInit() {
     this.service.employeelist();
  }

  onDelete(id : number) {
   this.service.deleteEmployee(id).subscribe(res =>{
   this.service.employeelist();
   });
  }

  onUpdate(emp: Employee) {
    this._router.navigate(['/create'])
  }

}
