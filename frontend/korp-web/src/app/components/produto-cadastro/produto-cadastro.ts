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
        alert('Produto cadastrado com sucesso!');
        this.router.navigate(['/produtos']);
      },
      error: (err) => {
        console.error('Erro ao cadastrar:', err);
        if (err.status === 0) {
          alert('Falha de conexão: Não foi possível alcançar o serviço de estoque.');
        } else if (err.status === 400) {
          alert('Erro nos dados: Verifique se as informações do produto estão corretas.');
        } else {
          alert('Ocorreu um erro inesperado ao salvar o produto.');
        }
      }
    });
  }
}