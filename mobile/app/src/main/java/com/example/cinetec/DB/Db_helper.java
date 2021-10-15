package com.example.cinetec.DB;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.cinetec.entities.Cinema;
import com.example.cinetec.entities.Movie;
import com.example.cinetec.entities.Projection;
import com.example.cinetec.entities.Seat;
import com.example.cinetec.network.NetworkCommunicator;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;


public class Db_helper extends SQLiteOpenHelper {
    private static final int DATABASE_VERSION=1;
    private static final String DATABASE_NAME="CINETEC.db";
    private static final String Client_table="Create Table If not exists Client( \n" +
            "Username text,\n"+
            "Password text,\n" +
            "Primary Key(Username)"+
            ");";
    private static final String Cinema_Table="Create Table If not exists Cinema( \n" +
            "Name text,\n" +
            "Primary Key(Name)"+
            ");";
    private static String Movie_Table="Create Table If not exists Movie(\n" +
            "Original_name text,\n"  +
            "Name text,\n" +
            "Image text,\n" +
            "Primary Key(Original_name)"+
            ");";
    private static String Projection_Table="Create Table If not exists Projection(\n" +
            "Id Integer,\n"  +
            "Date date,\n" +
            "Initial_time time,\n"  +
            "Movie_original_name text,\n" +
            "Cinema_name text,\n"+
            "Room_number Integer,\n"+
            "Primary Key(Id)\n"+
            ");";

    private static String Seat_table="Create Table If not exists Seat( \n" +
            "Projection_id Integer,\n"+
            "Number Integer,\n"+
            "State Integer,\n"+
            "Primary Key(Projection_id,Number)\n"+
            ")";

    private static String Order_table="Create Table If not exists Orden( \n" +
            "Client_username text,\n"+
            "Orden_ID Integer Primary Key Autoincrement\n"+
            ")";

    private static String Reserved_seat="Create Table If not exists Reserved_seat( \n" +
            "Projection_id Integer,\n"+
            "Seat_Number Integer,\n"+
            "Orden_ID Integer,\n"+
            "Primary Key(Projection_id,Seat_Number,Orden_ID)\n"+
            ");";
    private static String ClientsURl="http://25.92.13.1:38389/Admin/Client";
    private static final String CinemasURL="http://25.92.13.1:38389/Admin/Sucursales";
    private static final String MoviesURL="http://25.92.13.1:38389/Admin/Movies";
    private static final String ProjectionsURL="http://25.92.13.1:38389/Admin/Projections";
    private static final String SeatUrl="http://25.92.13.1:38389/Admin/Seats";
    public Db_helper(@Nullable Context context) {
        super(context, DATABASE_NAME, null,DATABASE_VERSION);
    }



    @Override
    public void onCreate(SQLiteDatabase DB) {
        DataBaseCreation(DB);
    }

    @Override
    public void onUpgrade(SQLiteDatabase DB, int i, int i1) {

    }
    public void DataBaseCreation(@NonNull SQLiteDatabase DB){
        DB.execSQL(Client_table);
        DB.execSQL(Cinema_Table);
        DB.execSQL(Movie_Table);
        DB.execSQL(Projection_Table);
        DB.execSQL(Seat_table);
        DB.execSQL(Order_table);
        DB.execSQL(Reserved_seat);
    }
    public void DataBaseDrop(@NonNull SQLiteDatabase DB){
        DB.execSQL("Drop Table IF Exists Client");
        DB.execSQL("Drop Table IF Exists Cinema");
        DB.execSQL("Drop Table IF Exists Movie");
        DB.execSQL("Drop Table IF Exists Projection");
        DB.execSQL("Drop Table IF Exists Seat");
        DB.execSQL("Drop Table IF Exists Orden");
        DB.execSQL("Drop Table IF Exists Reserved_seat");
    }
    public void Reset(SQLiteDatabase DB){
        DataBaseDrop(DB);
        DataBaseCreation(DB);
    }
    public void SyncProcess(){
        SQLiteDatabase DB=this.getWritableDatabase();
        this.Reset(DB);
        ContentValues contentValues=new ContentValues();
        contentValues.put("Username","Luis");
        contentValues.put("Password","1234");
        DB.insert("Client",null,contentValues);
        DB.close();
        //ArrayList<String> Cinema_names=new ArrayList<String>();
        NetworkCommunicator.get(ClientsURl, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                if(!response.isSuccessful())return;
                try {
                    JSONArray client_array=new JSONArray(response.body().source().readUtf8());
                    for(int i=0,size=client_array.length();i<size;i++){
                        JSONObject Movie=client_array.getJSONObject(i);
                        String username=Movie.getString("username");
                        String password=Movie.getString("password");
                        Log.d("EXITO",username);
                        Log.d("EXITO",password);
                        insertClient(username,password);
                    }



                }
                catch (Exception e){}


            }
        });

        NetworkCommunicator.get(CinemasURL, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                if(!response.isSuccessful())return;
                try {
                    String json=response.body().source().readUtf8();
                    JSONArray cinema_array=new JSONArray(json);
                    for(int i=0,size=cinema_array.length();i<size;i++){

                        JSONObject Cinema=cinema_array.getJSONObject(i);
                        String cinema_name=Cinema.getString("name");
                        insertCinema(cinema_name);
                    }



                }
                catch (Exception e){}


            }
        });



        NetworkCommunicator.get(MoviesURL, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {

                if(!response.isSuccessful())return;
                try {
                    String request_body=response.body().source().readUtf8();
                   // Log.d("MOVIE",request_body);
                    JSONArray movie_array=new JSONArray(request_body);
                    for(int i=0,size=movie_array.length();i<size;i++){
                        JSONObject Movie=movie_array.getJSONObject(i);
                        String Movie_original_name=Movie.getString("originalName");
                       // Log.d("MOVIE",Movie_original_name);
                        String Movie_name=Movie.getString("name");

                        String Movie_image_url=Movie.getString("image");
                        insertMovie(Movie_original_name,Movie_name,Movie_image_url);
                    }



                }
                catch (Exception e){}
            }
        });


        NetworkCommunicator.get(CinemasURL, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                if(!response.isSuccessful())return;
                try {
                    JSONObject object=new JSONObject(response.body().source().readUtf8());
                    String username=object.getString("Cinema_name");
                    String password=object.getString("password");
                    insertClient(username,password);

                }
                catch (Exception e){}
            }
        });
        NetworkCommunicator.get(ProjectionsURL, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {
                Log.d("PROJECTIONS","Falle projecciones");

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                Log.d("PROJECTIONS","Llegue a projections");
                if(!response.isSuccessful())return;
                try {
                    String request_body=response.body().source().readUtf8();
                    Log.d("PROJECTIONS",request_body);
                    JSONArray jsonArray=new JSONArray(request_body);
                    for(int i=0,size=jsonArray.length();i<size;i++){
                        JSONObject object=jsonArray.getJSONObject(i);
                        int id=object.getInt("id");
                        String movie_name=object.getString("movieOriginalName");
                        String cinema_name=object.getString("cinemaName");
                        String initial_time=object.getString("initialTime");
                        String date=object.getString("date");
                        int room_number=object.getInt("roomNumber");
                        insertProjection(id,movie_name,cinema_name,room_number,date,initial_time);

                    }


                }
                catch (Exception e){}
            }
        });

        NetworkCommunicator.get(SeatUrl, null, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                //Log.d("PROJECTIONS","Llegue a projections");
                if(!response.isSuccessful())return;
                try {
                    String request_body=response.body().source().readUtf8();
                   // Log.d("PROJECTIONS",request_body);
                    JSONArray jsonArray=new JSONArray(request_body);
                    for(int i=0,size=jsonArray.length();i<size;i++){
                        JSONObject object=jsonArray.getJSONObject(i);
                        int Projection_id=object.getInt("projectionId");
                        int number=object.getInt("seatNumber");
                        int state=object.getInt("state");
                        insertSeat(Projection_id,number,state);

                    }


                }
                catch (Exception e){}
            }
        });




    }
    public boolean changeSeatState(int Projection_id,int Seat_number,Integer state){
        String Projection_id_string=Integer.toString(Projection_id);
        String Seat_number_string=Integer.toString(Seat_number);
        SQLiteDatabase DB=this.getWritableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Seat where Projection_id=? and Number=?",new String[]{Projection_id_string,Seat_number_string});
        if(cursor.getCount()>0){
            ContentValues contentValues=new ContentValues();
            contentValues.put("Project_id",Projection_id);
            contentValues.put("Number",Seat_number);
            contentValues.put("State",state);
            long result=DB.update("Seat",contentValues,"Projection_id=? and Number=?",new String[]{Projection_id_string,Seat_number_string});
            DB.close();
            cursor.close();
            if(result==-1){
                return false;
            }
            else return true;
        }
        DB.close();
        cursor.close();
        return false;

    }
    public boolean insertClient(String username,String password){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Username",username);
        contentValues.put("Password",password);
        long result=DB.insert("Client",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }
    public boolean insertCinema(String Cinema_name){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Name",Cinema_name);
        long result=DB.insert("Cinema",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }
    public boolean insertMovie(String Movie_original_name,String Movie_name,String Movie_url){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Original_name",Movie_original_name);
        contentValues.put("Name",Movie_name);
        contentValues.put("Image",Movie_url);
        long result=DB.insert("Movie",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }
    public boolean insertProjection(int id,String Movie_original_name,String cinema_name,int Room_number,String date,String initial_time){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Id",id);
        contentValues.put("Movie_original_name",Movie_original_name);
        contentValues.put("Cinema_name",cinema_name);
        contentValues.put("Initial_time",initial_time);
        contentValues.put("Date",date);
        contentValues.put("Room_number",Room_number);
        long result=DB.insert("Projection",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }
    public boolean insertSeat(int Projection_id,int seat_number,int state){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Projection_Id",Projection_id);
        contentValues.put("Number",seat_number);
        contentValues.put("State",state);
        long result=DB.insert("Seat",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }


    public boolean insertReservedSeat(int Projection_id,int Seat_number,int Order_id){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Projection_id",Projection_id);
        contentValues.put("Seat_number",Seat_number);
        contentValues.put("Orden_id",Order_id);
        long result=DB.insert("Reserved_seat",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }


    public boolean addOrder(String Client_user){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("Client_username",Client_user);
        long result=DB.insert("Orden",null,contentValues);
        DB.close();
        if(result==-1){
            return false;
        }
        return true;
    }

    private int getClientLastOrder(){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Orden",null);
        if(cursor.getCount()<=0){
            DB.close();
            cursor.close();
            return -1;
        }
        cursor.moveToFirst();
        int biggest_index=cursor.getInt(1);
        int current=0;
        while(! cursor.isLast()){
            cursor.moveToNext();
            current=cursor.getInt(1);
            if(current>biggest_index){
                biggest_index=current;
            }
        }
        DB.close();
        cursor.close();
        return biggest_index;


    }
    public int getNextOrderID(){
        return  getClientLastOrder()+1;
    }
    public ArrayList<Cinema> getCinemas(){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Cinema",null);
        if(cursor.getCount()<=0){
            DB.close();
            cursor.close();
            return null;
        }
        ArrayList<Cinema> cinema_array=new ArrayList<>();

        cursor.moveToFirst();
        while(!cursor.isLast()){
            Cinema cinema=new Cinema(cursor.getString(0));
            cinema_array.add(cinema);
            cursor.moveToNext();
        }
        Cinema cinema=new Cinema(cursor.getString(0));
        cinema_array.add(cinema);
        DB.close();
        cursor.close();
        return cinema_array;
    }
    public ArrayList<Movie> getMovies(){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Movie",null);
        if(cursor.getCount()<=0){
            DB.close();
            cursor.close();
            return null;
        }
        ArrayList<Movie> movie_array=new ArrayList<>();

        cursor.moveToFirst();
        while(!cursor.isLast()){
            Movie movie=new Movie(cursor.getString(0),cursor.getString(1),cursor.getString(2));
            movie_array.add(movie);
            cursor.moveToNext();
        }
        Movie movie=new Movie(cursor.getString(0),cursor.getString(1),cursor.getString(2));
        movie_array.add(movie);
        DB.close();
        cursor.close();
        return movie_array;
    }
    public ArrayList<Projection> getProjection(String movie_name,String cinema_name){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Projection Where Movie_original_name=? AND Cinema_name=? Order by date,Initial_time",new String[]{movie_name,cinema_name});
        if(cursor.getCount()<=0){
            DB.close();
            cursor.close();
            return null;
        }

        ArrayList<Projection> projection_array=new ArrayList<>();
        cursor.moveToFirst();
        while(!cursor.isLast()){
            Projection projection=new Projection(cursor.getInt(0),cursor.getString(4),cursor.getInt(5),cursor.getString(3),cursor.getString(1),cursor.getString(2));
            projection_array.add(projection);
            cursor.moveToNext();
        }
        Projection projection=new Projection(cursor.getInt(0),cursor.getString(4),cursor.getInt(5),cursor.getString(3),cursor.getString(1),cursor.getString(2));
        projection_array.add(projection);
        DB.close();
        cursor.close();
        return projection_array;
    }
    public ArrayList<Seat> getSeat(int Projection_id){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * from Seat Where Projection_id=? Order by Number",new String[]{Integer.toString(Projection_id)});
        if(cursor.getCount()<=0){
            DB.close();
            cursor.close();
            return null;
        }

        ArrayList<Seat> seat_array=new ArrayList<>();
        cursor.moveToFirst();
        while(!cursor.isLast()){
            Seat seat=new Seat(cursor.getInt(0),cursor.getInt(1),cursor.getInt(2));
            seat_array.add(seat);
            cursor.moveToNext();
        }
        Seat seat=new Seat(cursor.getInt(0),cursor.getInt(1),cursor.getInt(2));
        seat_array.add(seat);
        DB.close();
        cursor.close();
        return seat_array;
    }


    public boolean verifyClient(String username,String password){
        SQLiteDatabase DB=this.getReadableDatabase();
        Cursor cursor=DB.rawQuery("Select * From Client where Username=? and Password=?",new String[]{username,password});
        if(cursor.getCount()<=0){
            return false;
        }
        return true;

    }
    //

    //Log.d("LOGIMPORTANTE",object.getString("people"));


}
