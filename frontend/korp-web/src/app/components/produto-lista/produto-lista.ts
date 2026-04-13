import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ProdutoService } from '../../services/produto';
import { Produto } from '../../models/produto.model';

@Component({
  selector: 'app-produto-lista',
  templateUrl: './produto-lista.html',
  standalone: false
})
export class ProdutoLista implements OnInit {
  produtos: Produto[] = [];
  constructor(
    private produtoService: ProdutoService,
    private cdRef: ChangeDetectorRef 
  ) { }

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.produtoService.getProdutos().subscribe({
      next: (dados) => {
        this.produtos = dados;
        console.log('Dados carregados:', this.produtos);
        this.cdRef.detectChanges(); 
      },
      error: (err) => console.error('Erro:', err)
    });
  }
}