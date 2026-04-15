import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProdutoService } from '../../services/produto';

@Component({
  selector: 'app-produto-cadastro',
  templateUrl: './produto-cadastro.html',
  standalone: false
})
export class ProdutoCadastro {
  produto = {
    codigo: '',
    descricao: '',
    preco: 0,
    saldo: 0
  };
  
  constructor(private service: ProdutoService, private router: Router) {}

  salvar() {
    this.service.criarProduto(this.produto).subscribe({
      next: () => {
        alert('Produto cadastrado com sucesso');
        this.router.navigate(['/produtos']);
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao salvar produto');
      }
    });
  }
}