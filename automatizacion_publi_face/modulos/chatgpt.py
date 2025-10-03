from openai import OpenAI

def generar_texto(key, prompt):
    try:
        client = OpenAI(api_key=key)
        respuesta = client.chat.completions.create(
            model="gpt-4.1-nano",
            messages=[{"role": "user", "content": prompt}],
            max_completion_tokens=100
        )
        return respuesta.choices[0].message.content.strip()
    except Exception as e:
        print(f"❌ Error al generar texto con ChatGPT: {e}")
        return "Texto de ejemplo porque la API falló."
