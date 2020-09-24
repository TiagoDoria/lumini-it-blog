import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { Publicar_postComponent } from './publicar_post/publicar_post.component';
import { Cadastro_usuarioComponent } from './cadastro_usuario/cadastro_usuario.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'publicar-post', component: Publicar_postComponent },
  { path: 'cadastrar-usuario', component: Cadastro_usuarioComponent },
  { path: 'login', component: LoginComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
