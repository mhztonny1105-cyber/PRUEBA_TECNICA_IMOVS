import requests

def publicar(token, id_page, prompt, imagen):
    try:
        url = f"https://graph.facebook.com/v23.0/{id_page}/photos"
        data = {
            "url": imagen,
            "caption": prompt,
            "access_token": token
        }
        response = requests.post(url, data=data)
        response.raise_for_status()  # Lanza error si status != 200
        return response.json()
    except requests.exceptions.RequestException as e:
        print(f"❌ Error al publicar en Facebook: {e}")
        return None
