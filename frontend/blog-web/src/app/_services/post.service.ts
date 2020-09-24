
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post }  from '../_models/Post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  baseURL = 'http://localhost:5001/api/post';

  constructor(private http: HttpClient) { }


  publicarPost(post: Post) {
    return this.http.post(this.baseURL, post);
  }

}
