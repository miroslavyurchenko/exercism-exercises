public static class TelemetryBuffer
{

    private static byte[] CreateBuffer(byte prefix, byte[] bytes){
        byte[] buffer = new byte[9];

        buffer[0] = prefix;
    
        Array.Copy(bytes, 0, buffer, 1, bytes.Length);
    
        return buffer;
    }

    public static byte[] ToBuffer(long reading)
    {

        
        if (reading >= 0 && reading <= ushort.MaxValue){
            return CreateBuffer(2, BitConverter.GetBytes((ushort)reading));
        }

         if (reading >= short.MinValue && reading <= short.MaxValue ){
            return CreateBuffer(254, BitConverter.GetBytes((short)reading));
        }

        if (reading >= int.MinValue && reading <= int.MaxValue){
            return CreateBuffer(252, BitConverter.GetBytes((int)reading));
        }

        if (reading >= 0 && reading <= uint.MaxValue){
            return CreateBuffer(4, BitConverter.GetBytes((uint)reading));
        }

       
            
        
        
        return CreateBuffer( 248, BitConverter.GetBytes(reading));
        }
    
/*    public static byte[] ToBuffer(long reading)
    {
        byte prefix = 248;

        byte[] bytes = BitConverter.GetBytes(reading);

        return CreateBuffer(prefix, bytes);
    }

    public static byte[] ToBuffer(ulong reading){
        byte prefix = 248;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    }

    public static byte[] ToBuffer(byte reading){
        
        byte prefix = 255;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    }


    public static byte[] ToBuffer(sbyte reading){
        byte prefix = 255;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    }
    
    
    public static byte[] ToBuffer(short reading){
        byte prefix = 254;

        byte[] bytes = BitConverter.GetBytes(reading);

        return CreateBuffer(prefix, bytes);
    }
    
    public static byte[] ToBuffer(ushort reading){
        byte prefix = 254;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    }

    public static byte[] ToBuffer(int reading){    
        byte prefix = 252;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    }

    public static byte[] ToBuffer(uint reading){  
        byte prefix = 252;
    
        byte[] bytes = BitConverter.GetBytes(reading);
    
        return CreateBuffer(prefix, bytes);
    } */
    
    public static long FromBuffer(byte[] buffer)
    {
        switch(buffer[0])
        {
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
    
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 254:
                return BitConverter.ToInt16(buffer, 1);
    
            case 252:
                return BitConverter.ToInt32(buffer, 1);
    
            case 248:
                return BitConverter.ToInt64(buffer, 1);
    
            default:
                return 0;
        }
    }
}
//int literal