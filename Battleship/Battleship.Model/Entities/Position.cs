namespace Battleship.Model.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Position() { }
        public Position (int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetNewValue(int col,int row)
        {
            this.Column = col;
            this.Row = row;
        }

        public override bool Equals(object obj)
        {
            Position ?p = obj as Position;
            if (p != null && p.Row == this.Row && p.Column == this.Column)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = Row + Column * 100;
            return hashCode;
        }
    }
}