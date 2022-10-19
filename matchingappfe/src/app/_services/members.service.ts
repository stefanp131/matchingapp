import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private accountService: AccountService) { }

  getMembers() : Observable<Member[]> {
    const username = this.accountService.currentUserSource.value.username;
    return this.http.get<Member[]>(`${this.baseUrl}users?username=${username}`);
  }
}
