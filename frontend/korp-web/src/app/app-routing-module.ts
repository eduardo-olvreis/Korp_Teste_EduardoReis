import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdutoLista } from './components/produto-lista/produto-lista';
import { NotaFiscalLista } from './components/nota-fiscal-lista/nota-fiscal-lista';
import { NotaFiscalCadastro } from './components/nota-fiscal-cadastro/nota-fiscal-cadastro';

const routes: Routes = [
  { path: 'produtos', component: ProdutoLista },
  { path: 'notas', component: NotaFiscalLista },
  { path: 'notas/nova', component: NotaFiscalCadastro },
  { path: '', redirectTo: '/produtos', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }