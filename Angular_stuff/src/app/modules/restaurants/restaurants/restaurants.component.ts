import { Component, OnDestroy, OnInit } from '@angular/core';    // clasa
import { MessageService } from 'src/app/services/message.service';
import { Restaurant } from 'src/app/interfaces/restaurant';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})


export class RestaurantsComponent implements OnInit, OnDestroy {

  // proprietati
  // restaurant : Restaurant = {
  //   id: '1',
  //   Name: "Vivo"
  // };

  public restaurants : Restaurant[] = [];
  // selectedRestaurant?: Restaurant;

  public subscription: Subscription | any;
  public loggedUser : any;
  public parentMessage = 'message from parent';
  
  ///////
  constructor(private restaurantService : RestaurantService, private messageService :  MessageService, private router: Router, private dataService: DataService) { }

  ngOnInit(): void {      // daca vrem sa initializam date -> pagina se va incarca doar dupa ce se incarca datele in memorie (life cicle al componentelor)
    this.getRestaurants();    // putem pune debugger unde vrem

    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role', 'Anonim');
    this.messageService.add("Logged out!");
    this.router.navigate(['/login']);
  }

  getRestaurants(): void {
    this.restaurantService.getRestaurants().subscribe((restaurants) => {
      this.restaurants = restaurants;
      debugger
      console.log(restaurants);
    });
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.restaurantService.addRestaurant({ name } as Restaurant)
      .subscribe(restaurant => {
        this.restaurants = restaurant;
      });
  }

  public receiveMessage(event: any): void {
    console.log(event);
  }

}
