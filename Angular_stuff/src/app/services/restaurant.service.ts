import { Injectable } from '@angular/core';
import { Restaurant } from '../interfaces/restaurant';
import { RESTAURANTS } from '../mock-data/mock-restaurants';
import { catchError, Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private restaurantUrl = "https://localhost:5001/api/Restaurant";    // de luat din enviroment
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(private messageService: MessageService, private http: HttpClient) { }

  getRestaurants(): Observable<Restaurant[]> {
    // this.log(`RestaurantService: fetched restaurants`);
    // debugger
    return this.http.get<Restaurant[]>(this.restaurantUrl)
    .pipe(
      tap(_ => this.log('fetched restaurants')),   // pentru a ne asigura ca nu dam request-ul la server daca acesta nu merge
      catchError(this.handleError<Restaurant[]>('getRestaurants', []))
    );
  }

  getRestaurant(Id: string): Observable<Restaurant> {
    // ruta cu parametru
    const url = `${this.restaurantUrl}/${Id}`;
    // debugger
    return this.http.get<Restaurant>(url)
    .pipe(
      tap(_ => this.log(`fetched restaurant id=${Id}`)),
      catchError(this.handleError<Restaurant>(`getRestaurant id=${Id}`))
    );
  }

  updateRestaurant(restaurant: Restaurant): Observable<any> {
    return this.http.put(this.restaurantUrl, restaurant, this.httpOptions)
    .pipe(
      tap(_ => this.log(`updated restaurant id=${restaurant.id}`)),
      catchError(this.handleError<any>('updateRestaurant'))
    );
  }

  addRestaurant(restaurant: Restaurant): Observable<any>  {
    restaurant.id = '8';
    return this.http.post(this.restaurantUrl, restaurant, this.httpOptions)
    .pipe(
      tap(_ => this.log(`added restaurant`)),
      catchError(this.handleError<any>('addRestaurant'))
    );
  }

  // ruta cu parametru
  deleteRestaurant(Id: string): Observable<any>  {
    return this.http.delete(`${this.restaurantUrl}/${Id}`, this.httpOptions)
    .pipe(
      tap(_ => this.log(`deleted restaurant}`)),
      catchError(this.handleError<any>('deleteRestaurant'))
    );
  }

  // observable data pentru a garanta ca operatiile vor fi facute asincron
  // getRestaurants(): Observable<Restaurant[]> {
  //   const restaurants = of(RESTAURANTS);
  //   this.messageService.add('RestaurantService: fetched restaurants');
  //   return of(RESTAURANTS);
  // }

  // getRestaurant(Id: string): Observable<Restaurant> {
  //   const restaurant = RESTAURANTS.find(r => r.Id === Id)!;
  //   this.log(`RestaurantService: fetched restaurant id=${Id}`);
  //   return of(restaurant);
  // }

  // wrapper pt MessageService 
  private log(message: string) {
  this.messageService.add(`RestaurantService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
