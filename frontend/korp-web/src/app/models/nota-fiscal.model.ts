export interface ItemNotaFiscal {
  produtoId: number;
  quantidade: number;
}

export interface NotaFiscal {
  id: number;
  numeroSequencial: number;
  status: string;
  itens: any[];
}