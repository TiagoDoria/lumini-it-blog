import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { Post } from '../_models/Post';
import { PostService } from '../_services/post.service';


@Component({
  selector: 'app-publicar_post',
  templateUrl: './publicar_post.component.html',
  styleUrls: ['./publicar_post.component.css']
})
export class Publicar_postComponent implements OnInit {

  registerForm: FormGroup;
  post: Post;

  constructor(
    private postService: PostService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.fb.group({
      titulo: ['', Validators.required],
      resumo: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(500)]],
      descricao: ['', [Validators.required, Validators.minLength(200)]]
    });
  }

  salvar() {
    if(this.registerForm.valid) {
      this.post = Object.assign({}, this.registerForm.value);
      console.log(this.post);
      this.postService.publicarPost(this.post).subscribe(
        (novoPost: Post) => {
          console.log(novoPost);
          this.toastr.success('Sucesso!', 'Publicação realizada!');
        }, error => {
          console.log(error);
          this.toastr.error('Erro!', 'Falha ao publicar!');
        }
      );
    }
  }

}
