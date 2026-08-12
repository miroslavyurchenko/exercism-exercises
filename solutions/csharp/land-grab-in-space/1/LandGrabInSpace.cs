public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot (Coord a, Coord b, Coord c, Coord d){
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public Coord A { get; }
    public Coord B { get; }
    public Coord C { get; }
    public Coord D { get; }
}


public class ClaimsHandler
{
    public List<Plot> claims = new List<Plot>();
    
    
    public void StakeClaim(Plot plot)
    {
        claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        foreach(Plot i in claims){
            if(i.Equals(plot)){
                return true;
            }
        }
        
        return false;
    }

    public bool IsLastClaim(Plot plot)
    {
        if(claims.Count() == 0){
            return false;
        }
        return claims[claims.Count - 1].Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot result = claims[0];
        int longest = 0;
    
        foreach (Plot claim in claims){
            int width = Math.Abs(claim.B.X - claim.A.X);
            int height = Math.Abs(claim.C.Y - claim.A.Y);
            int side = Math.Max(width, height);
    
            if (side > longest){
                longest = side;
                result = claim;
            }
        }
    
        return result;
    }

    
}