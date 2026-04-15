import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProdutoLista } from './components/produto-lista/produto-lista';
import { NotaFiscalLista } from './components/nota-fiscal-lista/nota-fiscal-lista';
import { NotaFiscalCadastro } from './components/nota-fiscal-cadastro/nota-fiscal-cadastro';

@NgModule({
  declarations: [
    App, 
    ProdutoLista, 
    NotaFiscalLista, 
    NotaFiscalCadastro
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    provideHttpClient(),
    provideBrowserGlobalErrorListeners(),
  ],
  bootstrap: [App],
})
export class AppModule {}