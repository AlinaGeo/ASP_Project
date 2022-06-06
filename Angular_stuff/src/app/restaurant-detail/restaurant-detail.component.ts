import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Restaurant } from '../interfaces/restaurant';
import { RestaurantService } from '../services/restaurant.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.css']
})
export class RestaurantDetailComponent implements OnInit {

  restaurant: Restaurant | undefined;    // trebuie sa gasim restaurantul cu id-ul din url

  constructor(
    private route: ActivatedRoute,    // pentru a rula id-ul din ruta
    private restaurantService: RestaurantService,
    private location: Location) { }   // este folosita pentru a tine un istoric al paginilor pe care am fost

  ngOnInit(): void {
    this.getRestaurant();
  }

  getRestaurant(): void {
    // debugger
    const id = String(this.route.snapshot.paramMap.get('id'));    // luam id-ul din ruta
    this.restaurantService.getRestaurant(id)
      .subscribe(restaurant => this.restaurant = restaurant);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.restaurant) {
      this.restaurantService.updateRestaurant(this.restaurant)
        .subscribe(() => this.goBack());    // subscribe pentru a avea siguranta ca server-ul a updatad db-ul
    }
  }
}
