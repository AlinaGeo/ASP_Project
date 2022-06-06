import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-dish-form',
  templateUrl: './dish-form.component.html',
  styleUrls: ['./dish-form.component.css']
})
export class DishFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private messageService: MessageService) { }

  dishForm = this.fb.group({
    Name: ['', Validators.required],
    ingrediente: this.fb.array([
      this.fb.control('')
    ])
  });

  ngOnInit(): void {
  }

  get ingrediente() {
    return this.dishForm.get('ingrediente') as FormArray;
  }

  addIngredient() {
    this.ingrediente.push(this.fb.control(''));
  }

  onSubmit() {
    console.log(this.dishForm.value);
    this.messageService.add("Multumim ca ati completat formularul!")
  }

}
