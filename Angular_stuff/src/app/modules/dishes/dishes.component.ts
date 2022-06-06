import { Component, OnInit } from '@angular/core';
import { Dish } from 'src/app/interfaces/dish';
import { DishesService } from 'src/app/services/dishes.service';

@Component({
  selector: 'app-dishes',
  templateUrl: './dishes.component.html',
  styleUrls: ['./dishes.component.css']
})
export class DishesComponent implements OnInit {

  constructor(private dishService: DishesService) { }
  public dish: Dish | any;

  ngOnInit(): void {
  }

  add(Name: string): void {
    Name = Name.trim();
    if (!Name) { return; }
    this.dishService.addDish({ Name } as Dish)
      .subscribe(dish => {
        this.dish = dish;
      });
  }

}
