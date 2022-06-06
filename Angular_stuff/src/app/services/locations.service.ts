import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class LocationsService {

  public url = 'https://localhost:5001/api/Location';
  constructor(
    public http: HttpClient,
    private messageService: MessageService,
  ) { }

  public getLocations(): Observable<any> {
    // debugger
    // const locations = this.http.get(`${this.url}/get_ordered_streets`);
    // console.log(locations);
    // this.log('fetched locations');
    return this.http.get<Location[]>(`${this.url}`)
    .pipe(
      tap(_ => this.log(`added restaurant`)),
      catchError(this.handleError<any>('addRestaurant'))
    );;
  }

  private log(message: string) {
    this.messageService.add(`LocationService: ${message}`);
    }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      console.error(error);
  
      this.log(`${operation} failed: ${error.message}`);
  
      return of(result as T);
    };
  }
}


