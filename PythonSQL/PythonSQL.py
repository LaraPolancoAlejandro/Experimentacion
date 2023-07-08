import json
import pyodbc
import time

start_time = time.time()
class UsuarioDto:
    def __init__(self, Nombre, Apellido, NumeroDocumentoIdentidad, TipoDeDocumento, Sexo, FechaNacimiento):
        self.Nombre = Nombre
        self.Apellido = Apellido
        self.NumeroDocumentoIdentidad = NumeroDocumentoIdentidad
        self.TipoDeDocumento = TipoDeDocumento
        self.Sexo = Sexo
        self.FechaNacimiento = FechaNacimiento

with open('C:\\Users\\ALP54\\source\\repos\\Experimentacion\\MOCK_DATA.json', 'r') as f:
    data = json.load(f)
    usuarios = [UsuarioDto(**usuario) for usuario in data]

connection_string = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=ALEJANDROPC\SQLEXPRESS02;DATABASE=Experimentacion;Trusted_Connection=yes;'
with pyodbc.connect(connection_string) as conn:
    cursor = conn.cursor()
    for usuario in usuarios:
        cursor.execute("""
            EXEC InsertarUsuario @Nombre = ?, @Apellido = ?, @NumeroDocumentoIdentidad = ?, @TipoDeDocumento = ?, @Sexo = ?, @FechaNacimiento = ?
        """, usuario.Nombre, usuario.Apellido, usuario.NumeroDocumentoIdentidad, usuario.TipoDeDocumento, usuario.Sexo, usuario.FechaNacimiento)
        conn.commit()

elapsed_time = time.time() - start_time
print(f"La transaccion utilizando Python tardo {elapsed_time } segundos")


