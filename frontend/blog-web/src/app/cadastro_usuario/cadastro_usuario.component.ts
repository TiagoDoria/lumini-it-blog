import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { Usuario } from '../_models/Usuario';
import { UsuarioService } from '../_services/usuario.service';

@Component({
  selector: 'app-cadastro_usuario',
  templateUrl: './cadastro_usuario.component.html',
  styleUrls: ['./cadastro_usuario.component.css']
})
export class Cadastro_usuarioComponent implements OnInit {

  registerForm: FormGroup;
  usuario: Usuario;

  constructor(
    private usuarioService: UsuarioService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.fb.group({
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10)]]
    });
  }

  salvar() {
    if(this.registerForm.valid) {
      this.usuario = Object.assign({}, this.registerForm.value);
      console.log(this.usuario);
      this.usuarioService.postUsuario(this.usuario).subscribe(
        (novoUsuario: Usuario) => {
          console.log(novoUsuario);
          this.toastr.success('Sucesso!', 'Cadastro realizado!');
        }, error => {
          console.log(error);
          this.toastr.error('Erro!', 'Falha ao cadastrar!');
        }
      );
    }
  }

}
