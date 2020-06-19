import { DetalleVenta } from "./detalle-venta";

export class Venta {
    fechadeventa: Date;
    estado: string;
    total: number;
    Detalles: DetalleVenta[];
}
