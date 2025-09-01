#!/bin/bash

# Inicia o Ollama em segundo plano
ollama serve &
pid=$!

# Aguarda o Ollama iniciar
sleep 5

echo "🔴 Baixando o modelo llama3.2:1b..."
ollama pull llama3.2:1b
echo "🟢 Pronto!"

# Mantém o processo do Ollama rodando
wait $pid
