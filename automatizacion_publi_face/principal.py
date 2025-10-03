from modulos.facebook import publicar
from modulos.chatgpt import generar_texto
from modulos.drive import obtener_imagen_aleatoria
from dotenv import load_dotenv
import os
import time

print("Publicando en Facebook automáticamente...")
# Cargar variables de entorno
load_dotenv()

TOKEN_FACEBOOK = os.getenv("FACEBOOK_TOKEN")
API_KEY_CHATGPT = os.getenv("OPENAI_API_KEY")
ID_PAGE_FACEBOOK = os.getenv("FACEBOOK_PAGE_ID")
ID_CARPETA= os.getenv("ID_CARPETA_DRIVE")

try:
    # Generar texto con ChatGPT
    prompt = generar_texto(API_KEY_CHATGPT, "Texto para vender un SDD externo de 256GB en 435 pesos mexicanos")
    #prompt="Prueba con drive"
    # Obtener imagen 
    url=obtener_imagen_aleatoria(ID_CARPETA)
    # Publicar en Facebook
    respuesta = publicar(TOKEN_FACEBOOK, ID_PAGE_FACEBOOK, prompt, url)
    print("✅ Publicación realizada:", respuesta)

except Exception as e:
    print("❌ Error en el proceso:", e)
