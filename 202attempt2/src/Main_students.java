import javax.xml.crypto.Data;
import java.io.File;
import java.io.InputStreamReader;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.lang.reflect.Array;
import java.util.ArrayList;


public class Main_students {

    public static ArrayList ReadData(String pathname) {
        ArrayList strlist = new ArrayList();
        try {

            File filename = new File(pathname);
            InputStreamReader reader = new InputStreamReader(
                    new FileInputStream(filename));
            BufferedReader br = new BufferedReader(reader);
            int j=0;
            String line ="";
            while ((line = br.readLine()) != null) {
                strlist.add(line);
            }
            return strlist;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return strlist;
    }

    public static ArrayList DataWash(ArrayList Datalist){
        ArrayList AIS = new ArrayList();
        ArrayList IS =new ArrayList();
        for (int i =0; i<Datalist.size();i++){
            String Tstr= (String)Datalist.get(i);
            if (Tstr.equals("A") == false){
                IS.add(Integer.parseInt(Tstr));
            }
            if (Tstr.equals("A")){
                AIS.add(IS.clone());
                IS.clear();
            }
        }
        return AIS;
    }



//%%%%%%%%%%%%%%%%%%%%%%% Procedure SquareNormClustering() that will contain your code:


    public static int SquareNormClustering(int[] A, int n, int k){
        /* Input is array of input sequence (a_1, a_2,…,a_n) as A[0,1,…,n-1], that is,
        a_1 = A[0], a_2 = A[1], …, a_n = A[n-1].
        n = number of integers in sequence A
        k = number of groups (k <= n)
        This procedure should return the value of the grouping with minimum possible 
        value of the objective function. It should NOT return the respective grouping!
        */
     
        /* Here should be the description of the main ideas of your solution: 
        describe the recursive relation used in your dynamic programming 
        solution and outline how you implement it in your code below.

        first the program completes the optimal solution for a single group (no cuts)
        then the optimal solution for a second group (one cut)
        and so on until the correct amount of groups has been reached.
        
        the program stores the optimal solution to previous groupings in a 2d array resultsArray
        when calculating a new value for the minimum possible value amongst all possible cuts, the program will use the optimal value
        of any previous calculations which are required when doing the calculation
        
        more is described throughout the actual code itself, namely in the findMinimum function
      
        */

        /* Here should be the statement and description of the running time 
        analysis of your implementation: describe how the running time depends on 
        n (length of the input sequence) and k (number of groups), and give short 
        argument.

        the initial population of the resultsArray causes the program to run at least in time kn, so O(n^2)
        the first for loop will run k-1 times, so O(n)
        the second for loop will run n-1 times, so O(n)
        the second for loop is nested in the first for loop so O(n^2)
        the final for loop in the main program also has time complexity O(n)
        the final for loop is nested in the second which is nested in the first
        
        so the final time complexity is O(n^3)

        */
 
    	int[][] resultsArray = new int[k][n];
    	for (int i=0; i<k; i++){
    		for (int i2=0; i2<n; i2++){
    			resultsArray[i][i2] = 0;
    		}
    	}
    	//first we need to set the first row in resultsArray as if everything was in a single group, i.e cuts = 0
    	//this will take n passes	
		for (int x = 0; x<n; x++){
    		resultsArray[0][x] = addNumbers(A, x+1, 0);
    	}
		//now need to do for rest of rows
		//each consecutive pass will be of n-1 length through the numbers since we can't possibly split n-1 numbers into n groups 
		
		//will need to do a nested for loop now
		//for each amount of cuts up to the maximum amount of cuts  (the first loop should stop at groupsNeeded - 1  as this is the amount of cuts needed to make that many groups
		for (int i=1; i<k; i++){
			//now for each element in the array, starting at the index needed (1 more than current cuts due to can't have >= cuts than numbers)
			//loop up until the last element in the array, this will always be n
    		for (int i2=i; i2<n; i2++){
    			//now we are iterating the correct amount of times we actually need to do the calculations
    			//first need to check if it is the first calculation being done for this row- we will need to calculate that separately as it's a new value completely
    			if (i == i2){
    				//we pass i into as the number to add as this is equal to the amount of elements to skip
    				//start position will always be 0 as we are adding the squares of the numbers up to element k or something
    				resultsArray[i][i2] = addNumbersSquared(A, i, 0);
    			} else {
    				//now we need to find the minimum of
    				//	resultsArray[i-1][i2] + (A[i2])^2
    				//  resultsArray[i-1][i2-1] + (A[i2] + A[i2-1])^2
    				//  resultsArray[i-1][i2-2] + (A[i2] + A[i2-1] + A[i2-2])^2
    				//	....
    				//  resultsArray[i-1][first] + (A[i2] + .... + A[first element + 1])
    				//while the value for x in resultsArray[][x] is greater than 0
    				resultsArray[i][i2] = findMinimum(resultsArray, A, i, i2);
    				
    			}
    		}
    	}
            
        return resultsArray[k - 1][n - 1]; // Here your procedure should return the objective value of the optimal
                  // solutions.
    } // end of procedure SquareNormClustering

    public static int addNumbers(int[] a, int numberToAdd, int startIndex){
    	//takes input of the array to add numbers from, the amount of numbers to add and the position at which we should start the adding
    	//returns the value of (sum of added elements)^2
    	int sum = 0;
    	for (int i=startIndex; i<numberToAdd; i++){
    		sum += a[i];
    	}
    	return sum * sum;
    }
    
    public static int addNumbersReverse(int[] a, int numberToAdd, int startIndex){
    	//takes input of the array to add numbers from, the amount of numbers to add and the position at which we should start the adding
    	//returns the value of (sum of added elements)^2
    	//differs from addNumbers in that it is a decreasing for loop
    	
    	int sum = 0;
    	int counter = 0;
    	while (counter != numberToAdd ){
    		sum += a[startIndex - counter];
    		counter +=1;
    	}
    	return sum * sum;
    }
    
    public static int addNumbersSquared(int[] a, int numberToAdd, int startIndex){
    	//takes input of the array to add numbers from, the amount of numbers to add and the position at which we should start the adding
    	//this differs from addNumbers as it returns the sum of (each element)^2
    	int sum = 0;
    	int tempInt = 0;
    	for (int i=startIndex; i<numberToAdd+1; i++){
    		tempInt = a[i];
    		tempInt = tempInt * tempInt;
    		sum += tempInt;
    	}
    	return sum;
    }
    
    public static int findMinimum(int[][] results, int[] numbers, int i, int i2){
    	
    	int minimum = 0;
    	int currentValue;
    	//used when checking the first iteration - guarantees the first will be set to minimum when minimum is empty at start
    	boolean isSet = false;
    	//loopCounter set to 1 due to the base case being done already
    	int loopCounter = 1;
    	//now we need to find the minimum of
		//	results[i-1][i2] + (numbers[startIndex])^2    															base case
    	
		//  results[i-1][i2-1] + (numbers[startIndex] + numbers[startIndex - 1])^2
    	
		//  results[i-1][i2-2] + (numbers[startIndex] + numbers[startIndex - 1] + numbers[startIndex-2])^2
    	
		//	....
    	
		//  results[i-1][i2=i] + (numbers[i2] + .... + numbers[i+1])
    	
    	//now we have the base case, we need to check everything that comes before it
    	//so we need to go down from i2 to i-1
    	
    	for (int index = i2; index > i-1; index--){
    		
    		//now need to find the minimum values
    		if (isSet == false){
    			minimum = addNumbersReverse(numbers, loopCounter, i2) + results[i-1][index - 1];
    			isSet = true;
    		} else {
    			currentValue = addNumbersReverse(numbers, loopCounter, i2) + results[i-1][index - 1];
    			if (currentValue < minimum){
    				minimum = currentValue;
    			}
    		}
    		loopCounter +=1;
    			
    	}    	
    	return minimum;
    }
    
    
//%%%%%%%%%%%%%%%%%%%%%%% End of your code



    public static int Computation(ArrayList Instance, int opt){
        int NGounp = 0;
        int size = 0;
        int Correct = 0;
        size = Instance.size();

        int [] A = new int[size-opt];
        // NGounp = Integer.parseInt((String)Instance.get(0));
        NGounp = (Integer)Instance.get(0);
        for (int i = opt; i< size;i++ ){
            A[i-opt] = (Integer)Instance.get(i);
        }
        int Size =A.length;
        if (NGounp >Size ){
            return (-1);
        }
        else {
            int R = SquareNormClustering(A, Size, NGounp);
            return(R);
        }
    }

    public static String Test;


    public static void main(String[] args) {
        Test = args[0];
        int opt = 2;
        String pathname = "data2.txt";
        if (Test.equals("-opt1")) {
            opt = 1;
            pathname = "data1.txt";
        }
        ArrayList Datalist = new ArrayList();
        Datalist = ReadData(pathname);
        ArrayList AIS = DataWash(Datalist);

        int Nins = AIS.size();
        int NGounp = 0;
        int size = 0;
        if (Test.equals("-opt1")) {
            for (int t = 0; t < Nins; t++) {
                int Correct = 0;
                int Result = 0;
                ArrayList Instance = (ArrayList) AIS.get(t);
                Result = Computation(Instance, opt);
                System.out.println(Result);
            }
        }
        else {
            int wrong_no = 0;
            int Correct = 0;
            int Result = 0;
            ArrayList Wrong = new ArrayList();
            for (int t = 0; t < Nins; t++) {
                ArrayList Instance = (ArrayList) AIS.get(t);
                Result = Computation(Instance, opt);
                System.out.println(Result);
                Correct = (Integer) Instance.get(1);
                if (Correct != Result) {
		    Wrong.add(t+1);
                    //Wrong.add(Instance);
                    wrong_no=wrong_no+1;
                }
            }
            if (Wrong.size() > 0) {System.out.println("Index of wrong instance(s):");}
            for (int j = 0; j < Wrong.size(); j++) {
		System.out.print(Wrong.get(j));
                System.out.print(",");
                
                /*ArrayList Instance = (ArrayList)Wrong.get(j);
                for (int k = 0; k < Instance.size(); k++){
                    System.out.println(Instance.get(k));
                }*/
            }
            System.out.println("");
            System.out.println("Percentage of correct answers:");
            System.out.println(((double)(Nins-wrong_no) / (double)Nins)*100);

        }

    }
}
