import random
from google.oauth2 import service_account
from googleapiclient.discovery import build

# Alcances mínimos para leer archivos de Drive
SCOPES = ['https://www.googleapis.com/auth/drive.readonly']
SERVICE_ACCOUNT_FILE = 'cuenta_servicio.json'

def conectar_drive():
    try:
        credenciales = service_account.Credentials.from_service_account_file(
        SERVICE_ACCOUNT_FILE, scopes=SCOPES
        )
        return build('drive', 'v3', credentials=credenciales)
    except Exception as e:
        print(f"❌ Error al conectar con drive: {e}") 

def obtener_imagen_aleatoria(carpeta_id):
    servicio = conectar_drive()
    # Buscar archivos dentro de la carpeta (solo imágenes)
    resultados = servicio.files().list(
        q=f"'{carpeta_id}' in parents and mimeType contains 'image/'",
        fields="files(id, name)"
    ).execute()
    archivos = resultados.get('files', [])
    if not archivos:
        return "No hay imágenes en la carpeta."

    # Escoger uno al azar
    elegido = random.choice(archivos)

    # URL pública de descarga / visualización
    url = f"https://drive.google.com/uc?id={elegido['id']}"
    return  url
