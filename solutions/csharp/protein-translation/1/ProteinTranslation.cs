public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        List<string> proteins = new List<string>();

        for(int i = 0; i < strand.Length; i+=3){
            
            string codon = strand.Substring(i, 3);
            switch(codon){
                case "AUG":
                    proteins.Add("Methionine");
                    break;
                case "UUU":
                case "UUC":
                    proteins.Add("Phenylalanine");
                    break;
                case "UUA":
                case "UUG":
                    proteins.Add("Leucine");
                    break;
                case "UCU":
                case "UCC":
                case "UCA":
                case "UCG":
                    proteins.Add("Serine");
                    break;
                case "UAU": 
                case "UAC":
                    proteins.Add("Tyrosine");
                    break;
                case "UGU": 
                case "UGC":
                    proteins.Add("Cysteine");
                    break;
                case "UGG":
                    proteins.Add("Tryptophan");
                    break;
                case "UAA":
                case "UAG":
                case "UGA":
                    return proteins.ToArray();
            }
        }
        return proteins .ToArray();
    }
}