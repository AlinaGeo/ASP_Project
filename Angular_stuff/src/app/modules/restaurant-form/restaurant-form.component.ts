import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-restaurant-form',
  templateUrl: './restaurant-form.component.html',
  styleUrls: ['./restaurant-form.component.css']
})
export class RestaurantFormComponent implements OnInit {
  name = new FormControl('');

  profileForm = new FormGroup({
    Name: new FormControl('', Validators.required),
    Id: new FormControl(''),
    adresa: new FormGroup({
      Strada: new FormControl('', Validators.required),
      Oras: new FormControl(''),
    })
  });

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
  }

  updateName() {
    this.name.setValue('Vivo');
  }

  updateInfo() {
    this.profileForm.patchValue({
      Name: 'Vivo',
      adresa: {
        Oras: 'Bucuresti'
      }
    })
  }

  onSubmit() {
    console.warn(this.profileForm.value);
    this.messageService.add("Multumim ca ati completat formularul!")
  }

}
