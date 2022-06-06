import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { Dish } from '../interfaces/dish';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class DishesService {
  private dishUrl = "https://localhost:5001/api/Dish";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(private messageService: MessageService, private http: HttpClient) { }

  addDish(dish: Dish): Observable<any>  {
    dish.Id = '25';
    // dish.Name = "New dish"
    dish.RestaurantId = '1';
    return this.http.post(`${this.dishUrl}/create_dish`, dish, this.httpOptions)
    .pipe(
      tap(_ => this.messageService.add(`DishesService: added dish`)),
      catchError(this.handleError<any>('addDish'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      console.error(error);
  
      this.messageService.add(`${operation} failed: ${error.message}`);
  
      return of(result as T);
    };
  }
}
